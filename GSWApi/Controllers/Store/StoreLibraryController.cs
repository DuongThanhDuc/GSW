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
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET: api/StoreLibrary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreLibraryDTO>>> GetAll()
        {
            var libraries = await _repository.GetAllAsync();
            if (libraries == null)
                return NotFound(new { success = false, message = "No library entries found" });

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
            if (string.IsNullOrWhiteSpace(userId))
                return BadRequest(new { success = false, message = "Invalid user ID" });

            var libraries = await _repository.GetByUserIdAsync(userId);
            if (libraries == null)
                return NotFound(new { success = false, message = "No library entries found for this user" });

            return Ok(new { success = true, data = libraries });
        }

        // POST: api/StoreLibrary
        [HttpPost]
        public async Task<IActionResult> Add(StoreLibraryDTO dto)
        {
            if (dto == null)
                return BadRequest(new { success = false, message = "Invalid library entry data" });

            await _repository.AddAsync(dto);

            return Ok(new { success = true, message = "Library entry added successfully" });
        }

        // PUT: api/StoreLibrary/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StoreLibraryDTO dto)
        {
            if (dto == null)
                return BadRequest(new { success = false, message = "Invalid library entry data" });

            if (id != dto.ID)
                return BadRequest(new { success = false, message = "ID mismatch" });

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new { success = false, message = "Library entry not found" });

            await _repository.UpdateAsync(dto);

            return Ok(new { success = true, message = "Library entry updated successfully" });
        }

        // DELETE: api/StoreLibrary/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new { success = false, message = "Library entry not found" });

            await _repository.DeleteAsync(id);

            return Ok(new { success = true, message = "Library entry deleted successfully" });
        }
    }
}
