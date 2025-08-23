using Microsoft.AspNetCore.Mvc;
using BusinessModel.Model;
using System.Threading.Tasks;
using DataAccess.Repository.IRepository;
using System;
using System.Linq;

namespace GSWApi.Controllers.Admin
{
    [Route("admin/[controller]")]
    [ApiController]
    public class SystemTagController : ControllerBase
    {
        private readonly ISystemTagRepository _tagRepository;

        public SystemTagController(ISystemTagRepository tagRepository)
        {
            _tagRepository = tagRepository ?? throw new ArgumentNullException(nameof(tagRepository));
        }

        // GET: admin/systemtag
        [HttpGet]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _tagRepository.GetAllAsync();
            if (tags == null || !tags.Any())
                return NotFound(new { success = false, message = "No tags found." });

            return Ok(new { success = true, data = tags });
        }

        // GET: admin/systemtag/id/5
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetTagById(int id)
        {
            if (id <= 0)
                return BadRequest(new { success = false, message = "Invalid ID." });

            var tag = await _tagRepository.GetByIdAsync(id);
            if (tag == null)
                return NotFound(new { success = false, message = "Tag not found." });

            return Ok(new { success = true, data = tag });
        }

        // GET: admin/systemtag/name/sometag
        [HttpGet("name/{name}")]
        public async Task<IActionResult> GetTagByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest(new { success = false, message = "Tag name cannot be null or empty." });

            var tag = await _tagRepository.GetByNameAsync(name);
            if (tag == null)
                return NotFound(new { success = false, message = "Tag not found." });

            return Ok(new { success = true, data = tag });
        }

        // POST: admin/systemtag
        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] SystemTag tag)
        {
            if (tag == null)
                return BadRequest(new { success = false, message = "Tag cannot be null." });

            if (string.IsNullOrWhiteSpace(tag.TagName))
                return BadRequest(new { success = false, message = "Tag name is required." });

            await _tagRepository.AddAsync(tag);
            return Ok(new
            {
                success = true,
                message = "Tag created successfully.",
                data = tag
            });
        }

        // PUT: admin/systemtag/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(int id, [FromBody] SystemTag updatedTag)
        {
            if (updatedTag == null)
                return BadRequest(new { success = false, message = "Tag cannot be null." });

            if (id != updatedTag.ID)
                return BadRequest(new { success = false, message = "ID mismatch." });

            if (string.IsNullOrWhiteSpace(updatedTag.TagName))
                return BadRequest(new { success = false, message = "Tag name is required." });

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
                data = existingTag
            });
        }

        // DELETE: admin/systemtag/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            if (id <= 0)
                return BadRequest(new { success = false, message = "Invalid ID." });

            var existingTag = await _tagRepository.GetByIdAsync(id);
            if (existingTag == null)
                return NotFound(new { success = false, message = "Tag not found." });

            await _tagRepository.DeleteAsync(id);
            return Ok(new
            {
                success = true,
                message = "Tag deleted successfully.",
                data = new { id }
            });
        }
    }
}
