using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Games
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
        public async Task<ActionResult<IEnumerable<GamesInfoDTO>>> GetAllGamesDTO()
        {
            var games = await _repository.GetAllAsync();
            return Ok(games);
        }

        // GET: api/GamesInfo/model
        [HttpGet("model")]
        public async Task<ActionResult<IEnumerable<GamesInfo>>> GetAllGamesOriginal()
        {
            var games = await _repository.GetAllAsyncOriginal();
            return Ok(games);
        }

        // GET: api/GamesInfo/dto/5
        [HttpGet("dto/{id}")]
        public async Task<ActionResult<GamesInfoDTO>> GetGameByIdDTO(int id)
        {
            var game = await _repository.GetByIdAsync(id);
            if (game == null) return NotFound();
            return Ok(game);
        }

        // GET: api/GamesInfo/model/5
        [HttpGet("model/{id}")]
        public async Task<ActionResult<GamesInfo>> GetGameByIdOriginal(int id)
        {
            var game = await _repository.GetByIdAsyncOriginal(id);
            if (game == null) return NotFound();
            return Ok(game);
        }

        // POST: api/GamesInfo
        [HttpPost]
        public async Task<ActionResult<GamesInfoDTO>> CreateGame(GamesInfoDTO dto)
        {
            var createdGame = await _repository.CreateAsync(dto);
            return CreatedAtAction(nameof(GetGameByIdDTO), new { id = createdGame.ID }, createdGame);
        }

        // PUT: api/GamesInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, GamesInfoDTO dto)
        {
            if (id != dto.ID) return BadRequest("ID mismatch.");

            var success = await _repository.UpdateAsync(dto);
            if (!success) return NotFound();

            return NoContent();
        }

        // DELETE: api/GamesInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var success = await _repository.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
