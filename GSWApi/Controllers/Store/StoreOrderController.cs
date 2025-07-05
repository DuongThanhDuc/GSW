using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace GSWApi.Controllers.Store
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreOrderController : ControllerBase
    {
        private readonly IStoreOrderRepository _storeOrderRepository;

        public StoreOrderController(IStoreOrderRepository storeOrderRepository)
        {
            _storeOrderRepository = storeOrderRepository;
        }

        // GET: api/storeorder
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _storeOrderRepository.GetAllAsync();
            return Ok(new { success = true, data = orders });
        }

        // GET: api/storeorder/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _storeOrderRepository.GetByIdAsync(id);
            if (order == null)
                return NotFound(new { success = false, message = "Order not found" });

            return Ok(new { success = true, data = order });
        }

        // POST: api/storeorder
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StoreOrderDTO dto)
        {
            var createdOrder = await _storeOrderRepository.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdOrder.ID }, new { success = true, data = createdOrder });
        }

        // PUT: api/storeorder/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StoreOrderDTO dto)
        {
            var result = await _storeOrderRepository.UpdateAsync(id, dto);
            if (!result)
                return NotFound(new { success = false, message = "Order not found" });

            return Ok(new { success = true });
        }

        // DELETE: api/storeorder/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _storeOrderRepository.DeleteAsync(id);
            if (!result)
                return NotFound(new { success = false, message = "Order not found" });

            return Ok(new { success = true });
        }
    }
}
