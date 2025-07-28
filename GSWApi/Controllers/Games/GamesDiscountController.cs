using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Controllers.Games
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesDiscountController : ControllerBase
    {
        private readonly IGamesDiscountRepository _repository;

        public GamesDiscountController(IGamesDiscountRepository repository)
        {
            _repository = repository;
        }

        // Hàm random code
        private string GenerateDiscountCode(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // Hàm tự động deactivate các discount hết hạn
        private void DeactivateExpiredDiscounts()
        {
            var now = DateTime.UtcNow;
            var expired = _repository.GetAll().Where(d => d.IsActive && d.EndDate <= now).ToList();
            foreach (var d in expired)
            {
                d.IsActive = false;
                _repository.Update(d.Id, d);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            DeactivateExpiredDiscounts(); // Tự động update discount hết hạn
            var now = DateTime.UtcNow;
            var models = _repository.GetAll()
                .Where(d => d.IsActive && d.EndDate > now) // chỉ trả về các mã còn hiệu lực
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            var dtos = models.Select(d => new GamesDiscountDTO
            {
                Id = d.Id,
                Code = d.Code,
                Description = d.Description,
                Value = d.Value,
                IsPercent = d.IsPercent,
                StartDate = d.StartDate,
                EndDate = d.EndDate,
                IsActive = d.IsActive,
                CreatedAt = d.CreatedAt
            }).ToList();
            return Ok(new { success = true, data = dtos });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var d = _repository.Get(id);
            if (d == null)
                return NotFound(new { success = false, message = "Discount not found." });

            // Kiểm tra còn hạn không
            if (!d.IsActive || d.EndDate <= DateTime.UtcNow)
                return BadRequest(new { success = false, message = "Discount expired or inactive." });

            var dto = new GamesDiscountDTO
            {
                Id = d.Id,
                Code = d.Code,
                Description = d.Description,
                Value = d.Value,
                IsPercent = d.IsPercent,
                StartDate = d.StartDate,
                EndDate = d.EndDate,
                IsActive = d.IsActive,
                CreatedAt = d.CreatedAt
            };
            return Ok(new { success = true, data = dto });
        }

        [HttpPost]
        public IActionResult Create([FromBody] GamesDiscountDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = "Invalid model." });

            // Random code nếu không nhập
            if (string.IsNullOrWhiteSpace(dto.Code))
                dto.Code = GenerateDiscountCode();

            var now = DateTime.UtcNow;
            dto.StartDate = now;
            if (dto.EndDate <= now)
                return BadRequest(new { success = false, message = "EndDate must be after current time." });

            if (_repository.IsCodeExist(dto.Code))
                return BadRequest(new { success = false, message = "Code already exists." });

            var entity = new GamesDiscount
            {
                Code = dto.Code,
                Description = dto.Description,
                Value = dto.Value,
                IsPercent = dto.IsPercent,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsActive = true,
                CreatedAt = now
            };

            var created = _repository.Create(entity);
            dto.Id = created.Id;
            dto.CreatedAt = created.CreatedAt;

            return Ok(new { success = true, data = dto });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GamesDiscountDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { success = false, message = "Invalid model." });

            if (dto.EndDate < dto.StartDate)
                return BadRequest(new { success = false, message = "EndDate must be after StartDate." });

            var now = DateTime.UtcNow;
            // Nếu update start date trong quá khứ thì không cho phép
            if (dto.EndDate <= now)
                return BadRequest(new { success = false, message = "EndDate must be after current time." });

            var entity = new GamesDiscount
            {
                Id = id,
                Code = dto.Code,
                Description = dto.Description,
                Value = dto.Value,
                IsPercent = dto.IsPercent,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsActive = dto.IsActive,
                CreatedAt = dto.CreatedAt
            };

            var updated = _repository.Update(id, entity);
            if (updated == null)
                return NotFound(new { success = false, message = "Discount not found." });

            var result = new GamesDiscountDTO
            {
                Id = updated.Id,
                Code = updated.Code,
                Description = updated.Description,
                Value = updated.Value,
                IsPercent = updated.IsPercent,
                StartDate = updated.StartDate,
                EndDate = updated.EndDate,
                IsActive = updated.IsActive,
                CreatedAt = updated.CreatedAt
            };

            return Ok(new { success = true, data = result });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound(new { success = false, message = "Discount not found." });
            }
            _repository.Delete(id);
            return Ok(new { success = true, data = $"Discount {id} deleted successfully." });
        }

        // Lấy discount active của game
        [HttpGet("by-game/{gameId}")]
        public IActionResult GetActiveDiscountByGame(int gameId)
        {
            var d = _repository.GetActiveDiscountByGameId(gameId);

            // Chỉ trả discount còn hiệu lực
            if (d == null || !d.IsActive || d.EndDate <= DateTime.UtcNow)
                return NotFound(new { success = false, message = "No active discount for this game." });

            var dto = new GamesDiscountDTO
            {
                Id = d.Id,
                Code = d.Code,
                Description = d.Description,
                Value = d.Value,
                IsPercent = d.IsPercent,
                StartDate = d.StartDate,
                EndDate = d.EndDate,
                IsActive = d.IsActive,
                CreatedAt = d.CreatedAt
            };
            return Ok(new { success = true, data = dto });
        }

        // Gán discount cho game (deactive discount cũ nếu có)
        [HttpPost("assign/{gameId}/{discountId}")]
        public IActionResult AssignDiscountToGame(int gameId, int discountId)
        {
            if (gameId == 0)
                return NotFound(new { success = false, message = $"Game with ID {gameId} not found." });

            if (discountId == 0)
                return NotFound(new { success = false, message = $"Discount with ID {discountId} not found." });

            // Kiểm tra discount còn hiệu lực
            var discount = _repository.Get(discountId);
            if (discount == null || !discount.IsActive || discount.EndDate <= DateTime.UtcNow)
                return BadRequest(new { success = false, message = "Discount is not active or expired." });

            _repository.SetDiscountForGame(gameId, discountId);
            return Ok(new { success = true, data = $"Discount {discountId} assigned to Game {gameId}." });
        }

        [HttpDelete("remove/{gameId}/{discountId}")]
        public IActionResult RemoveDiscountFromGame(int gameId, int discountId)
        {
            if (gameId == 0)
                return NotFound(new { success = false, message = $"Game with ID {gameId} not found." });

            if (discountId == 0)
                return NotFound(new { success = false, message = $"Discount with ID {discountId} not found." });

            _repository.RemoveDiscountFromGame(gameId, discountId);
            return Ok(new { success = true, data = $"Discount {discountId} removed from Game {gameId}." });
        }
    }
}
