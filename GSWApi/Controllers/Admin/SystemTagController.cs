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
        public async Task<ActionResult<IEnumerable<SystemTag>>> GetAllTags()
        {
            var tags = await _tagRepository.GetAllAsync();
            return Ok(tags);
        }

        // GET: admin/systemtag/id/5
        [HttpGet("id/{id}")]
        public async Task<ActionResult<SystemTag>> GetTagById(int id)
        {
            var tag = await _tagRepository.GetByIdAsync(id);
            if (tag == null)
                return NotFound();

            return Ok(tag);
        }

        // GET: admin/systemtag/name/sometag
        [HttpGet("name/{name}")]
        public async Task<ActionResult<SystemTag>> GetTagByName(string name)
        {
            var tag = await _tagRepository.GetByNameAsync(name);
            if (tag == null)
                return NotFound();

            return Ok(tag);
        }

        // POST: admin/systemtag
        [HttpPost]
        public async Task<ActionResult> CreateTag([FromBody] SystemTag tag)
        {
            await _tagRepository.AddAsync(tag);
            return CreatedAtAction(nameof(GetTagById), new { id = tag.ID }, tag);
        }

        // PUT: admin/systemtag/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTag(int id, [FromBody] SystemTag updatedTag)
        {
            if (id != updatedTag.ID)
                return BadRequest("ID mismatch");

            var existingTag = await _tagRepository.GetByIdAsync(id);
            if (existingTag == null)
                return NotFound();

            existingTag.TagName = updatedTag.TagName;
            existingTag.CreatedBy = updatedTag.CreatedBy;

            await _tagRepository.UpdateAsync(existingTag);
            return NoContent();
        }

        // DELETE: admin/systemtag/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTag(int id)
        {
            var existingTag = await _tagRepository.GetByIdAsync(id);
            if (existingTag == null)
                return NotFound();

            await _tagRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
