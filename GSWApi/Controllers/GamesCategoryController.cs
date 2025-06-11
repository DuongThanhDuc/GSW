using BusinessModel.Model;
using DataAccess.DTOs;
using Microsoft.AspNetCore.Mvc;
using Repository.Repository.IRepository;

namespace GSWApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesCategoryController : ControllerBase
    {
        private readonly IGamesCategoryRepository _repo;

        public GamesCategoryController(IGamesCategoryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repo.GetAllAsync();
            var result = items.Select(x => new GamesCategoryDTO
            {
                ID = x.ID,
                GameID = x.GameID,
                CategoryID = x.CategoryID,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                GameName = x.Game?.Title,
                CategoryName = x.Category?.CategoryName
            });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _repo.GetByIdAsync(id);
            if (x == null) return NotFound();
            var dto = new GamesCategoryDTO
            {
                ID = x.ID,
                GameID = x.GameID,
                CategoryID = x.CategoryID,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                GameName = x.Game?.Title,
                CategoryName = x.Category?.CategoryName
            };
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGamesCategoryDTO dto)
        {
            var entity = new GamesCategory
            {
                GameID = dto.GameID,
                CategoryID = dto.CategoryID,
                CreatedBy = dto.CreatedBy,
                CreatedAt = DateTime.Now
            };
            var created = await _repo.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = created.ID }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGamesCategoryDTO dto)
        {
            var entity = new GamesCategory
            {
                GameID = dto.GameID,
                CategoryID = dto.CategoryID,
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
