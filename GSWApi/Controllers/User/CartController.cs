using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GSWApi.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IStoreCartRepository _cartRepository;

        public CartController(IStoreCartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        // GET: api/cart
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carts = await _cartRepository.GetAllAsync();
            return Ok(new
            {
                success = true,
                data = carts
            });
        }

        // GET: api/cart/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cart = await _cartRepository.GetByIdAsync(id);
            if (cart == null)
                return NotFound(new { success = false, message = "Cart not found." });

            return Ok(new
            {
                success = true,
                data = cart
            });
        }

        // GET: api/cart/user/{id}
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetByUserId(string id)
        {
            var cart = await _cartRepository.GetByUserIdAsync(id);
            if (cart == null)
                return NotFound(new { success = false, message = "Cart not found." });

            return Ok(new
            {
                success = true,
                data = cart
            });
        }

        // POST: api/cart
        [HttpPost]
        public async Task<IActionResult> Create(CartDTO dto)
        {
            var createdCart = await _cartRepository.CreateAsync(dto);
            return Ok(new
            {
                success = true,
                message = "Cart created successfully.",
                data = createdCart
            });
        }

        // PUT: api/cart/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CartDTO dto)
        {
            if (id != dto.ID)
                return BadRequest(new { success = false, message = "ID mismatch." });

            var success = await _cartRepository.UpdateAsync(dto);
            if (!success)
                return NotFound(new { success = false, message = "Cart not found." });

            return Ok(new
            {
                success = true,
                message = "Cart updated successfully.",
                data = dto
            });
        }

        // DELETE: api/cart/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _cartRepository.DeleteAsync(id);
            if (!success)
                return NotFound(new { success = false, message = "Cart not found." });

            return Ok(new
            {
                success = true,
                message = "Cart deleted successfully.",
                data = new { id }
            });
        }
    }
}
