using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Controllers.Store
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreOrderDetailController : ControllerBase
    {
        private readonly IStoreOrderDetailRepository _storeOrderDetailRepository;

        public StoreOrderDetailController(IStoreOrderDetailRepository storeOrderDetailRepository)
        {
            _storeOrderDetailRepository = storeOrderDetailRepository;
        }

        // GET: api/storeorderdetail
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var details = await _storeOrderDetailRepository.GetAllAsync();
            return Ok(new { success = true, data = details });
        }

        // GET: api/storeorderdetail/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var detail = await _storeOrderDetailRepository.GetByIdAsync(id);
            if (detail == null)
                return NotFound(new { success = false, message = "Order detail not found" });

            return Ok(new { success = true, data = detail });
        }

        // POST: api/storeorderdetail
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StoreOrderDetailDTO dto)
        {
            var createdDetail = await _storeOrderDetailRepository.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdDetail.ID }, new { success = true, data = createdDetail });
        }

        // PUT: api/storeorderdetail/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StoreOrderDetailDTO dto)
        {
            var result = await _storeOrderDetailRepository.UpdateAsync(id, dto);
            if (!result)
                return NotFound(new { success = false, message = "Order detail not found" });

            return Ok(new { success = true });
        }

        // DELETE: api/storeorderdetail/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _storeOrderDetailRepository.DeleteAsync(id);
            if (!result)
                return NotFound(new { success = false, message = "Order detail not found" });

            return Ok(new { success = true });
        }
    }
}
