using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesTagController : ControllerBase
    {
        private readonly IGamesTagRepository _repo;

        public GamesTagController(IGamesTagRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repo.GetAllAsync();
            var result = items.Select(x => new GamesTagDTO
            {
                ID = x.ID,
                GameID = x.GameID,
                TagID = x.TagID,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                GameName = x.Game?.Title,
                TagName = x.Tag?.TagName
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _repo.GetByIdAsync(id);
            if (x == null) return NotFound();
            var dto = new GamesTagDTO
            {
                ID = x.ID,
                GameID = x.GameID,
                TagID = x.TagID,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                GameName = x.Game?.Title,
                TagName = x.Tag?.TagName
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGamesTagDTO dto)
        {
            var entity = new GamesTag
            {
                GameID = dto.GameID,
                TagID = dto.TagID,
                CreatedBy = dto.CreatedBy,
                CreatedAt = DateTime.Now
            };
            var created = await _repo.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.ID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGamesTagDTO dto)
        {
            var entity = new GamesTag
            {
                GameID = dto.GameID,
                TagID = dto.TagID,
                CreatedBy = dto.CreatedBy
            };
            var updated = await _repo.UpdateAsync(id, entity);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repo.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
