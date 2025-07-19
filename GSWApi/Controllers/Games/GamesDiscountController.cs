using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository;
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

        [HttpGet]
        public IActionResult GetAll()
        {
            var models = _repository.GetAll();
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
            if (d == null) return NotFound(new { success = false, message = "Discount not found." });

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

            if (dto.EndDate < dto.StartDate)
                return BadRequest(new { success = false, message = "EndDate must be after StartDate." });

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
                IsActive = dto.IsActive
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
            var entity = new GamesDiscount
            {
                Id = id,
                Code = dto.Code,
                Description = dto.Description,
                Value = dto.Value,
                IsPercent = dto.IsPercent,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsActive = dto.IsActive
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
            if(id == null)
            {
                return NotFound(new { success = false, message = "Discount not found." });
            }
            _repository.Delete(id);
            return Ok(new { success = true, data = $"Discount {id} deleted successfully." });
        }

        // --- API lấy discount active của game ---
        [HttpGet("by-game/{gameId}")]
        public IActionResult GetActiveDiscountByGame(int gameId)
        {
            var d = _repository.GetActiveDiscountByGameId(gameId);
            if (d == null) return NotFound();

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
            return Ok(dto);
        }

        // Gán discount cho game (deactive discount cũ nếu có)
        [HttpPost("assign/{gameId}/{discountId}")]
        public IActionResult AssignDiscountToGame(int gameId, int discountId)
        {
            if (gameId == null)
                return NotFound(new { success = false, message = $"Game with ID {gameId} not found." });

            if (discountId == null)
                return NotFound(new { success = false, message = $"Discount with ID {discountId} not found." });

            _repository.SetDiscountForGame(gameId, discountId);
            return Ok(new { success = true, data = $"Discount {discountId} assigned to Game {gameId}." });
        }

        [HttpDelete("remove/{gameId}/{discountId}")]
        public IActionResult RemoveDiscountFromGame(int gameId, int discountId)
        {
            if (gameId == null)
                return NotFound(new { success = false, message = $"Game with ID {gameId} not found." });

            if (discountId == null)
                return NotFound(new { success = false, message = $"Discount with ID {discountId} not found." });

            _repository.RemoveDiscountFromGame(gameId, discountId);
            return Ok(new { success = true, data = $"Discount {discountId} removed from Game {gameId}." });
        }
    }
}
