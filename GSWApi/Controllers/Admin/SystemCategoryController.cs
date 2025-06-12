using Microsoft.AspNetCore.Mvc;
using BusinessModel.Model;
using DataAccess.Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSWApi.Controllers.Admin
{
    [Route("admin/[controller]")]
    [ApiController]
    public class SystemCategoryController : ControllerBase
    {
        private readonly ISystemCategoryRepository _categoryRepo;

        public SystemCategoryController(ISystemCategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        // GET: admin/systemcategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemCategory>>> GetAll()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return Ok(categories);
        }

        // GET: admin/systemcategory/id/5
        [HttpGet("id/{id}")]
        public async Task<ActionResult<SystemCategory>> GetById(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // GET: admin/systemcategory/name/{name}
        [HttpGet("name/{name}")]
        public async Task<ActionResult<SystemCategory>> GetByName(string name)
        {
            var category = await _categoryRepo.GetByNameAsync(name);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // POST: admin/systemcategory
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] SystemCategory category)
        {
            await _categoryRepo.AddAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = category.ID }, category);
        }

        // PUT: admin/systemcategory/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] SystemCategory updatedCategory)
        {
            if (id != updatedCategory.ID)
                return BadRequest("ID mismatch");

            var existing = await _categoryRepo.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            existing.CategoryName = updatedCategory.CategoryName;
            existing.CreatedBy = updatedCategory.CreatedBy;

            await _categoryRepo.UpdateAsync(existing);
            return NoContent();
        }

        // DELETE: admin/systemcategory/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existing = await _categoryRepo.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _categoryRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
