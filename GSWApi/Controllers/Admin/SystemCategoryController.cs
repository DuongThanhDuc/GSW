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
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return Ok(new
            {
                success = true,
                data = categories
            });
        }

        // GET: admin/systemcategory/id/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null)
                return NotFound(new { success = false, message = "Category not found." });

            return Ok(new
            {
                success = true,
                data = category
            });
        }

        // GET: admin/systemcategory/name/{name}
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var category = await _categoryRepo.GetByNameAsync(name);
            if (category == null)
                return NotFound(new { success = false, message = "Category not found." });

            return Ok(new
            {
                success = true,
                data = category
            });
        }

        // POST: admin/systemcategory
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SystemCategory category)
        {
            await _categoryRepo.AddAsync(category);
            return Ok(new
            {
                success = true,
                message = "Category created successfully.",
                data = category
            });
        }

        // PUT: admin/systemcategory/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SystemCategory updatedCategory)
        {
            if (id != updatedCategory.ID)
                return BadRequest(new { success = false, message = "ID mismatch." });

            var existing = await _categoryRepo.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new { success = false, message = "Category not found." });

            existing.CategoryName = updatedCategory.CategoryName;
            existing.CreatedBy = updatedCategory.CreatedBy;

            await _categoryRepo.UpdateAsync(existing);
            return Ok(new
            {
                success = true,
                message = "Category updated successfully.",
                data = existing
            });
        }

        // DELETE: admin/systemcategory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _categoryRepo.GetByIdAsync(id);
            if (existing == null)
                return NotFound(new { success = false, message = "Category not found." });

            await _categoryRepo.DeleteAsync(id);
            return Ok(new
            {
                success = true,
                message = "Category deleted successfully.",
                data = new { id }
            });
        }
    }
}
