using Microsoft.AspNetCore.Mvc;
using BusinessModel.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Repository.IRepository;

namespace GSWApi.Controllers.Admin
{
    [Route("admin/[controller]")]
    [ApiController]
    public class SystemTagController : ControllerBase
    {
        private readonly ISystemTagRepository _tagRepository;

        public SystemTagController(ISystemTagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        // GET: admin/systemtag
        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _tagRepository.GetAllAsync();
            return Ok(new { success = true, data = tags });
        }

        // GET: admin/systemtag/id/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);
            if (tag == null)
                return NotFound(new { success = false, message = "Tag not found." });

            return Ok(new { success = true, data = new[] { tag } });
        }

        // GET: admin/systemtag/name/sometag
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetTagByName(string name)
        {
            var tag = await _tagRepository.GetByNameAsync(name);
            if (tag == null)
                return NotFound(new { success = false, message = "Tag not found." });

            return Ok(new { success = true, data = new[] { tag } });
        }

        // POST: admin/systemtag
        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] SystemTag tag)
        {
            await _tagRepository.AddAsync(tag);
            return Ok(new
            {
                success = true,
                message = "Tag created successfully.",
                data = new[] { tag }
            });
        }

        // PUT: admin/systemtag/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(int id, [FromBody] SystemTag updatedTag)
        {
            if (id != updatedTag.ID)
                return BadRequest(new { success = false, message = "ID mismatch." });

            var existingTag = await _tagRepository.GetByIdAsync(id);
            if (existingTag == null)
                return NotFound(new { success = false, message = "Tag not found." });

            existingTag.TagName = updatedTag.TagName;
            existingTag.CreatedBy = updatedTag.CreatedBy;

            await _tagRepository.UpdateAsync(existingTag);
            return Ok(new
            {
                success = true,
                message = "Tag updated successfully.",
                data = new[] { existingTag }
            });
        }

        // DELETE: admin/systemtag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var existingTag = await _tagRepository.GetByIdAsync(id);
            if (existingTag == null)
                return NotFound(new { success = false, message = "Tag not found." });

            await _tagRepository.DeleteAsync(id);
            return Ok(new
            {
                success = true,
                message = "Tag deleted successfully.",
                data = new[] { new { id } }
            });
        }
    }
}
