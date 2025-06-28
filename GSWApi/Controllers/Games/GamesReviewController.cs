using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GSWApi.Controllers.Games
{
    [ApiController]
    [Route("api/games/reviews")]
    public class GamesReviewController : ControllerBase
    {
        private readonly IGamesReviewRepository _repository;

        public GamesReviewController(IGamesReviewRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GamesReviewDTO>>> GetAll()
        {
            var reviews = await _repository.GetAllAsync();
            var dtos = reviews.Select(MapToDTO).ToList();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GamesReviewDTO>> GetById(int id)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review == null) return NotFound();
            return Ok(MapToDTO(review));
        }

        [HttpGet("by-game/{gameId}")]
        public async Task<ActionResult<IEnumerable<GamesReviewDTO>>> GetByGameId(int gameId)
        {
            var reviews = await _repository.GetByGameIdAsync(gameId);
            var dtos = reviews.Select(MapToDTO).ToList();
            return Ok(dtos);
        }

        [HttpGet("by-user/{userId}")]
        public async Task<ActionResult<IEnumerable<GamesReviewDTO>>> GetByUserId(string userId)
        {
            var reviews = await _repository.GetByUserIdAsync(userId);
            var dtos = reviews.Select(MapToDTO).ToList();
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] GamesReviewDTO dto)
        {
            var review = new GamesReview
            {
                GameID = dto.GameID,
                UserID = dto.UserID,
                StarCount = dto.StarCount,
                Comment = dto.Comment,
                CreatedAt = DateTime.Now
            };
            await _repository.AddAsync(review);
            dto.ID = review.ID;
            dto.CreatedAt = review.CreatedAt;
            return CreatedAtAction(nameof(GetById), new { id = review.ID }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] GamesReviewDTO dto)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review == null) return NotFound();

            // Chỉ cho phép update StarCount và Comment
            review.StarCount = dto.StarCount;
            review.Comment = dto.Comment;
            await _repository.UpdateAsync(review);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }

        private static GamesReviewDTO MapToDTO(GamesReview r) =>
            new GamesReviewDTO
            {
                ID = r.ID,
                GameID = r.GameID,
                UserID = r.UserID,
                StarCount = r.StarCount,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt
            };
    }
}
