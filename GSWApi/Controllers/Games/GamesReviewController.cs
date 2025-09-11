using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
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
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var dtos = await _repository.GetAllAsync();
            if (dtos == null)
                return NotFound(new { success = false, message = "No reviews found" });

            return Ok(new
            {
                success = true,
                data = dtos
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var dto = await _repository.GetByIdAsync(id);
            if (dto == null)
                return NotFound(new { success = false, message = "Review not found" });

            return Ok(new
            {
                success = true,
                data = dto
            });
        }

        [HttpGet("by-game/{gameId}")]
        public async Task<ActionResult> GetByGameId(int gameId)
        {
            var dtos = await _repository.GetByGameIdAsync(gameId);
            if (dtos == null)
                return NotFound(new { success = false, message = "No reviews found for this game" });

            return Ok(new
            {
                success = true,
                data = dtos
            });
        }

        [HttpGet("by-user/{userId}")]
        public async Task<ActionResult> GetByUserId(string userId)
        {
            var dtos = await _repository.GetByUserIdAsync(userId);
            if (dtos == null)
                return NotFound(new { success = false, message = "No reviews found for this user" });

            return Ok(new
            {
                success = true,
                data = dtos
            });
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] GamesReviewDTO dto)
        {
            if (dto == null)
                return BadRequest(new { success = false, message = "Invalid review data" });

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

            return Ok(new
            {
                success = true,
                data = dto
            });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] GamesReviewDTO dto)
        {
            if (dto == null)
                return BadRequest(new { success = false, message = "Invalid review data" });

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new { success = false, message = "Review not found" });

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

            return Ok(new
            {
                success = true,
                message = "Review updated successfully"
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new { success = false, message = "Review not found" });

            await _repository.DeleteAsync(id);

            return Ok(new
            {
                success = true,
                message = "Review deleted successfully"
            });
        }
    }
}
