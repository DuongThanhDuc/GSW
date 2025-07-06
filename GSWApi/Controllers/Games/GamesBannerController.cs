using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GSWApi.Controllers.Games
{
    [ApiController]
    [Route("api/games/banner")]
    public class GamesBannerController : ControllerBase
    {
        private readonly IGamesBannerRepository _repo;
        public GamesBannerController(IGamesBannerRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult CreateBanner([FromBody] GamesBannerDTO dto)
        {
            _repo.CreateBanner(dto);
            return Ok(new { message = "Banner created." });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBanner(int id, [FromBody] GamesBannerDTO dto)
        {
            _repo.UpdateBanner(id, dto);
            return Ok(new { message = "Banner updated." });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBanner(int id)
        {
            _repo.DeleteBanner(id);
            return Ok(new { message = "Banner deleted." });
        }

        [HttpGet("{id}")]
        public ActionResult<GamesBannerDTO> GetBannerById(int id)
        {
            var result = _repo.GetBannerById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public ActionResult<IEnumerable<GamesBannerDTO>> GetAllBanners()
        {
            var result = _repo.GetAllBanners();
            return Ok(result);
        }
    }
}
