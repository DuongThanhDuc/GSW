using DataAccess.DTOs;
using GSWApi.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GSWApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JwtTokenGenerator _tokenGenerator;
        private readonly EmailService _emailService;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, JwtTokenGenerator tokenGenerator, EmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
            _emailService = emailService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            var user = new IdentityUser { UserName = dto.Username, Email = dto.Email, PhoneNumber= dto.PhoneNumber, EmailConfirmed = false };
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            await _userManager.AddToRoleAsync(user, "User");

            // Sinh OTP, gửi mail
            var otp = OtpManager.GenerateOtp(dto.Email);
            await _emailService.SendOtpEmail(dto.Email, otp);

            return Ok("Đã gửi OTP xác thực đến email. Vui lòng kiểm tra hộp thư.");
        }


        [HttpPost("verify-register-otp")]
        public async Task<IActionResult> VerifyRegisterOtp([FromBody] VerifyOtpDto dto)
        {
            if (OtpManager.VerifyOtp(dto.Email, dto.Otp))
            {
                var user = await _userManager.FindByEmailAsync(dto.Email);
                if (user == null) return BadRequest("Không tìm thấy tài khoản!");

                user.EmailConfirmed = true; // đánh dấu đã xác thực mail
                await _userManager.UpdateAsync(user);

                return Ok("Đăng ký thành công, tài khoản đã kích hoạt!");
            }
            return BadRequest("OTP không đúng hoặc đã hết hạn.");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user == null || !user.EmailConfirmed)
                return BadRequest("Tài khoản không hợp lệ hoặc chưa xác thực email!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded)
                return BadRequest("Sai tài khoản hoặc mật khẩu!");

            // Gửi OTP đăng nhập
            var otp = OtpManager.GenerateOtp(user.Email);
            await _emailService.SendOtpEmail(user.Email, otp);

            return Ok("OTP đã gửi về email!");
        }

        [HttpPost("verify-login-otp")]
        public async Task<IActionResult> VerifyLoginOtp([FromBody] VerifyOtpDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Không tìm thấy tài khoản"
                });
            }

            if (OtpManager.VerifyOtp(dto.Email, dto.Otp))
            {
                var roles = await _userManager.GetRolesAsync(user);
                var token = _tokenGenerator.GenerateToken(user, roles);

                return Ok(new
                {
                    success = true,
                    data = new[]
                    {
                new
                {
                    token,
                    username = user.UserName,
                    email = user.Email,
                    roles = roles
                }
            }
                });
            }

            return BadRequest(new
            {
                success = false,
                message = "OTP sai hoặc hết hạn!"
            });
        }


    }
}

