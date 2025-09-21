using BusinessModel.Model;
using DataAccess.DTOs;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Repository.IRepository;

namespace GSWApi.Controllers.Games
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesCategoryController : ControllerBase
    {
        private readonly IGamesCategoryRepository _repo;

        public GamesCategoryController(IGamesCategoryRepository repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repo.GetAllAsync();
            if (items == null)
                return NotFound(new { success = false, message = "No GamesCategories found." });

            var result = items.Select(x => new GamesCategoryDTO
            {
                ID = x.ID,
                GameID = x.GameID,
                CategoryID = x.CategoryID,
                CreatedAt = x.CreatedAt,
                CreatedBy = x.CreatedBy,
                GameName = x.Game?.Title,
                Img = x.Game?.CoverImagePath,
                CategoryName = x.Category?.CategoryName
            });

            return Ok(new
            {
                success = true,
                data = result
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var x = await _repo.GetByIdAsync(id);
            if (x == null)
                return NotFound(new { success = false, message = "GamesCategory not found." });

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

            return Ok(new
            {
                success = true,
                data = dto
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGamesCategoryDTO dto)
        {
            if (dto == null)
                return BadRequest(new { success = false, message = "Invalid GamesCategory data." });

            var entity = new GamesCategory
            {
                GameID = dto.GameID,
                CategoryID = dto.CategoryID,
                CreatedBy = dto.CreatedBy,
                CreatedAt = DateTime.Now
            };

            var created = await _repo.AddAsync(entity);
            if (created == null)
                return BadRequest(new { success = false, message = "Failed to create GamesCategory." });

            return Ok(new
            {
                success = true,
                message = "GamesCategory created successfully.",
                data = created
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGamesCategoryDTO dto)
        {
            if (dto == null)
                return BadRequest(new { success = false, message = "Invalid GamesCategory data." });

            var entity = new GamesCategory
            {
                GameID = dto.GameID,
                CategoryID = dto.CategoryID,
                CreatedBy = dto.CreatedBy
            };

            var updated = await _repo.UpdateAsync(id, entity);
            if (updated == null)
                return NotFound(new { success = false, message = "GamesCategory not found." });

            return Ok(new
            {
                success = true,
                message = "GamesCategory updated successfully.",
                data = updated
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _repo.DeleteAsync(id);
            if (!success)
                return NotFound(new { success = false, message = "GamesCategory not found." });

            return Ok(new
            {
                success = true,
                message = "GamesCategory deleted successfully.",
                data = new { id }
            });
        }
    }
}
