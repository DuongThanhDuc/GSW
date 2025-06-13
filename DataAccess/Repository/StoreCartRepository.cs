using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class StoreCartRepository : IStoreCartRepository
    {
        private readonly DBContext _context;

        public StoreCartRepository(DBContext context)
        {
            _context = context;
        }

        // Return the original model
        public async Task<IEnumerable<StoreCart>> GetAllAsyncOriginal()
        {
            return await _context.Store_Cart.ToListAsync();
        }

        // Return the original model
        public async Task<StoreCart?> GetByIdAsyncOriginal(int id)
        {
            return await _context.Store_Cart.FindAsync(id);
        }

        public async Task<IEnumerable<CartDTO>> GetAllAsync()
        {
            return await _context.Store_Cart
                .Select(c => new CartDTO
                {
                    ID = c.ID,
                    UserID = c.UserID,
                    GameID = c.GameID,
                    AddedAt = c.AddedAt
                }).ToListAsync();
        }

        public async Task<CartDTO?> GetByIdAsync(int id)
        {
            var cart = await _context.Store_Cart.FindAsync(id);
            if (cart == null) return null;

            return new CartDTO
            {
                ID = cart.ID,
                UserID = cart.UserID,
                GameID = cart.GameID,
                AddedAt = cart.AddedAt
            };
        }

        public async Task<CartDTO> CreateAsync(CartDTO dto)
        {
            var cart = new StoreCart
            {
                UserID = dto.UserID,
                GameID = dto.GameID,
                AddedAt = dto.AddedAt == default ? DateTime.Now : dto.AddedAt
            };

            _context.Store_Cart.Add(cart);
            await _context.SaveChangesAsync();

            dto.ID = cart.ID;
            return dto;
        }

        public async Task<bool> UpdateAsync(CartDTO dto)
        {
            var cart = await _context.Store_Cart.FindAsync(dto.ID);
            if (cart == null) return false;

            cart.UserID = dto.UserID;
            cart.GameID = dto.GameID;
            cart.AddedAt = dto.AddedAt;

            _context.Store_Cart.Update(cart);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cart = await _context.Store_Cart.FindAsync(id);
            if (cart == null) return false;

            _context.Store_Cart.Remove(cart);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
