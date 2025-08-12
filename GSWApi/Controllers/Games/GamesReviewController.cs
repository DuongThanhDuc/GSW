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
        public async Task<ActionResult<IEnumerable<GamesReviewDTOReadOnly>>> GetAll()
        {
            var dtos = await _repository.GetAllAsync();
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GamesReviewDTOReadOnly>> GetById(int id)
        {
            var dto = await _repository.GetByIdAsync(id);
            if (dto == null) return NotFound();
            return Ok(dto);
        }

        [HttpGet("by-game/{gameId}")]
        public async Task<ActionResult<IEnumerable<GamesReviewDTOReadOnly>>> GetByGameId(int gameId)
        {
            var dtos = await _repository.GetByGameIdAsync(gameId);
            return Ok(dtos);
        }

        [HttpGet("by-user/{userId}")]
        public async Task<ActionResult<IEnumerable<GamesReviewDTOReadOnly>>> GetByUserId(string userId)
        {
            var dtos = await _repository.GetByUserIdAsync(userId);
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] GamesReviewDTO dto)
        {
            var review = new GamesReview
            {
                GameID = dto.GameID,
                UserID = dto.UserID,
                IsUpvoted = dto.IsUpvoted,
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
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            // Load entity version for update
            var reviewEntity = new GamesReview
            {
                ID = id,
                GameID = dto.GameID,
                UserID = dto.UserID,
                IsUpvoted = dto.IsUpvoted,
                Comment = dto.Comment,
                CreatedAt = dto.CreatedAt
            };

            await _repository.UpdateAsync(reviewEntity);
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
                IsUpvoted = r.IsUpvoted,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt
            };
    }
}
