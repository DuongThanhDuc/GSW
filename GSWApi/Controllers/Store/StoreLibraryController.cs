using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Controllers.Store
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreLibraryController : ControllerBase
    {
        private readonly IStoreLibraryRepository _repository;

        public StoreLibraryController(IStoreLibraryRepository repository)
        {
            _repository = repository;
        }

        // GET: api/StoreLibrary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreLibraryDTO>>> GetAll()
        {
            var libraries = await _repository.GetAllAsync();
            return Ok(new { success = true, data = libraries });
        }

        // GET: api/StoreLibrary/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreLibraryDTO>> GetById(int id)
        {
            var library = await _repository.GetByIdAsync(id);
            if (library == null)
                return NotFound(new { success = false, message = "Library entry not found" });

            return Ok(new { success = true, data = library });
        }

        // GET: api/StoreLibrary/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<StoreLibraryDTO>>> GetByUserId(string userId)
        {
            var libraries = await _repository.GetByUserIdAsync(userId);
            return Ok(new { success = true, data = libraries });
        }

        // POST: api/StoreLibrary
        [HttpPost]
        public async Task<IActionResult> Add(StoreLibraryDTO dto)
        {
            await _repository.AddAsync(dto);
            return Ok(new { success = true, message = "Library entry added successfully" });
        }

        // PUT: api/StoreLibrary/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StoreLibraryDTO dto)
        {
            if (id != dto.ID)
                return BadRequest(new { success = false, message = "ID mismatch" });

            await _repository.UpdateAsync(dto);
            return Ok(new { success = true, message = "Library entry updated successfully" });
        }

        // DELETE: api/StoreLibrary/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok(new { success = true, message = "Library entry deleted successfully" });
        }
    }
}
