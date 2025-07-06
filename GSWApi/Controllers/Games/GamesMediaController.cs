using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Controllers.Games
{
    [ApiController]
    [Route("api/games/{gameId}/media")]
    public class GamesMediaController : ControllerBase
    {
        private readonly IGamesMediaRepository _repo;
        public GamesMediaController(IGamesMediaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetGameInfoWithMedia(int gameId)
        {
            var data = _repo.GetGameInfoWithMedia(gameId);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AddMedia(int gameId, [FromBody] GamesMediaDTO mediaDto)
        {
            _repo.AddMediaToGame(gameId, mediaDto);
            return Ok(new { message = "Media added." });
        }

        [HttpPut("{mediaId}")]
        public IActionResult UpdateMedia(int gameId, int mediaId, [FromBody] GamesMediaDTO mediaDto)
        {
            if (mediaDto.Id != mediaId) return BadRequest();
            _repo.UpdateMediaInGame(gameId, mediaDto);
            return Ok(new { message = "Media updated." });
        }

        [HttpDelete("{mediaId}")]
        public IActionResult DeleteMedia(int gameId, int mediaId)
        {
            _repo.DeleteMediaFromGame(gameId, mediaId);
            return Ok(new { message = "Media deleted." });
        }
    }
}
