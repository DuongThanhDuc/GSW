using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Controllers.Games
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesInfoController : ControllerBase
    {
        private readonly IGamesInfoRepository _repository;

        public GamesInfoController(IGamesInfoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/GamesInfo/dto
        [HttpGet("dto")]
        public async Task<IActionResult> GetAllGamesDTO()
        {
            var games = await _repository.GetAllAsync();
            return Ok(new
            {
                success = true,
                data = games
            });
        }

        // GET: api/GamesInfo/model
        [HttpGet("model")]
        public async Task<IActionResult> GetAllGamesOriginal()
        {
            var games = await _repository.GetAllAsyncOriginal();
            return Ok(new
            {
                success = true,
                data = games
            });
        }

        // GET: api/GamesInfo/dto/5
        [HttpGet("dto/{id}")]
        public async Task<IActionResult> GetGameByIdDTO(int id)
        {
            var game = await _repository.GetByIdAsync(id);
            if (game == null)
                return NotFound(new { success = false, message = "Game not found." });

            return Ok(new
            {
                success = true,
                data = game
            });
        }

        // GET: api/GamesInfo/model/5
        [HttpGet("model/{id}")]
        public async Task<IActionResult> GetGameByIdOriginal(int id)
        {
            var game = await _repository.GetByIdAsyncOriginal(id);
            if (game == null)
                return NotFound(new { success = false, message = "Game not found." });

            return Ok(new
            {
                success = true,
                data = game
            });
        }

        // POST: api/GamesInfo
        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] GamesInfoDTO dto)
        {
            if (dto == null)
                return BadRequest(new { success = false, message = "Invalid game data." });

            var createdGame = await _repository.CreateAsync(dto);
            return Ok(new
            {
                success = true,
                message = "Game created successfully.",
                data = createdGame
            });
        }

        // PUT: api/GamesInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, [FromBody] GamesInfoDTO dto)
        {
            if (dto == null || id != dto.ID)
                return BadRequest(new { success = false, message = "ID mismatch or invalid data." });

            var updated = await _repository.UpdateAsync(dto);
            if (!updated)
                return NotFound(new { success = false, message = "Game not found." });

            return Ok(new
            {
                success = true,
                message = "Game updated successfully.",
                data = dto
            });
        }

        // DELETE: api/GamesInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
                return NotFound(new { success = false, message = "Game not found." });

            return Ok(new
            {
                success = true,
                message = "Game deleted successfully.",
                data = new { id }
            });
        }
    }
}
