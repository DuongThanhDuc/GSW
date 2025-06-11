using DataAccess.DTOs;
using DataAccess.IRepository;
using DataAccess.Repository;
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
        public async Task<ActionResult<IEnumerable<CartDTO>>> GetAll()
        {
            var carts = await _cartRepository.GetAllAsync();
            return Ok(carts);
        }

        // GET: api/cart/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<CartDTO>> GetById(int id)
        {
            var cart = await _cartRepository.GetByIdAsync(id);
            if (cart == null) return NotFound();

            return Ok(cart);
        }

        // POST: api/cart
        [HttpPost]
        public async Task<ActionResult<CartDTO>> Create(CartDTO dto)
        {
            var createdCart = await _cartRepository.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdCart.ID }, createdCart);
        }

        // PUT: api/cart/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CartDTO dto)
        {
            if (id != dto.ID) return BadRequest("ID mismatch.");

            var success = await _cartRepository.UpdateAsync(dto);
            if (!success) return NotFound();

            return NoContent();
        }

        // DELETE: api/cart/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _cartRepository.DeleteAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
