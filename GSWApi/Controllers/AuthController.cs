using DataAccess.DTOs;
using GSWApi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

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
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
            {
                return BadRequest("Email is already registered.");
            }

            var user = new IdentityUser
            {
                UserName = dto.Username,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);


            await _userManager.AddToRoleAsync(user, "User");

            var displayNameClaim = new Claim("DisplayName", dto.Username); 
            await _userManager.AddClaimAsync(user, displayNameClaim);

            var otp = OtpManager.GenerateOtp(dto.Email);
            await _emailService.SendOtpEmail(dto.Email, otp);

            return Ok("An OTP has been sent to your email for verification. Please check your inbox.");
        }


        [HttpPost("verify-register-otp")]
        public async Task<IActionResult> VerifyRegisterOtp([FromBody] VerifyOtpDto dto)
        {
            if (OtpManager.VerifyOtp(dto.Email, dto.Otp))
            {
                var user = await _userManager.FindByEmailAsync(dto.Email);
                if (user == null) return BadRequest("Account not found!");

                user.EmailConfirmed = true; 
                await _userManager.UpdateAsync(user);

                return Ok("Registration successful, your account has been activated!");
            }
            return BadRequest("OTP is incorrect or has expired.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user == null || !user.EmailConfirmed)
                return BadRequest("Invalid account or email not verified!");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded)
                return BadRequest("Incorrect username or password!");

            // Send login OTP
            var otp = OtpManager.GenerateOtp(user.Email);
            await _emailService.SendOtpEmail(user.Email, otp);

            return Ok("An OTP has been sent to your email!");
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
                    message = "Account not found."
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
                            userid = user.Id,
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
                message = "OTP is incorrect or has expired."
            });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null || !user.EmailConfirmed)
                return BadRequest(new { success = false, message = "Email does not exist or is not verified!" });

            var otp = OtpManager.GenerateOtp(dto.Email);
            await _emailService.SendOtpEmail(dto.Email, otp);

            return Ok(new { success = true, data = "An OTP for password reset has been sent to your email." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            var email = OtpManager.GetEmailByOtp(dto.Otp); 
            if (string.IsNullOrEmpty(email))
                return BadRequest(new { success = false, message = "OTP is incorrect or has expired." });

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return BadRequest(new { success = false, message = "Account not found." });

            if (dto.NewPassword != dto.ConfirmPassword)
                return BadRequest(new { success = false, message = "Password confirmation does not match!" });

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, dto.NewPassword);

            if (!result.Succeeded)
                return BadRequest(new { success = false, message = "Password reset failed.", errors = result.Errors });

            return Ok(new { success = true, data = "Password has been reset successfully!" });
        }
    }
}
