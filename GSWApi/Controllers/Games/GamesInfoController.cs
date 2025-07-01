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
        public async Task<IActionResult> CreateGame(GamesInfoDTO dto)
        {
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
        public async Task<IActionResult> UpdateGame(int id, GamesInfoDTO dto)
        {
            if (id != dto.ID)
                return BadRequest(new { success = false, message = "ID mismatch." });

            var success = await _repository.UpdateAsync(dto);
            if (!success)
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
            var success = await _repository.DeleteAsync(id);
            if (!success)
                return NotFound(new { success = false, message = "Game not found." });

            return Ok(new
            {
                success = true,
                message = "Game deleted successfully.",
                data = new { id }
            });
        }

        // Kích hoạt game
        [HttpPost("{id}/active")]
        public async Task<IActionResult> ActiveGame(int id)
        {
            var success = await _repository.SetActiveStatusAsync(id, true);
            if (!success)
                return NotFound(new { success = false, message = "Game not found." });
            return Ok(new { success = true, message = "Game activated successfully." });
        }

        // Vô hiệu hóa game
        [HttpPost("{id}/deactive")]
        public async Task<IActionResult> DeactiveGame(int id)
        {
            var success = await _repository.SetActiveStatusAsync(id, false);
            if (!success)
                return NotFound(new { success = false, message = "Game not found." });
            return Ok(new { success = true, message = "Game deactivated successfully." });
        }

        // Đổi status game
        public class UpdateGameStatusDTO
        {
            public string Status { get; set; }
        }

        [HttpPost("{id}/status")]
        public async Task<IActionResult> UpdateGameStatus(int id, [FromBody] UpdateGameStatusDTO dto)
        {
            var success = await _repository.UpdateStatusAsync(id, dto.Status);
            if (!success)
                return NotFound(new { success = false, message = "Game not found." });
            return Ok(new { success = true, message = $"Game status updated to {dto.Status}." });
        }


    }
}
