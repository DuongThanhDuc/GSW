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
        private readonly IGamesInfoRepository _gamesRepo;

        public StoreCartRepository(DBContext context, IGamesInfoRepository gamesRepo)
        {
            _context = context;
            _gamesRepo = gamesRepo;
        }

        public async Task<IEnumerable<CartViewDTO>> GetAllAsync()
        {
            var carts = await _context.Store_Cart.ToListAsync();

            var result = new List<CartViewDTO>();

            foreach (var cart in carts)
            {
                var game = await _gamesRepo.GetByIdAsync(cart.GameID);
                if (game == null) continue;

                var discount = game.ActiveDiscounts.FirstOrDefault();
                var discountValue = discount?.Value ?? 0;
                var isPercent = discount?.IsPercent ?? false;
                var finalPrice = isPercent ? game.Price * (1 - (discountValue / 100)) : game.Price - discountValue;

                result.Add(new CartViewDTO
                {
                    ID = cart.ID,
                    UserID = cart.UserID,
                    GameID = cart.GameID,
                    GameName = game.Title,
                    Price = game.Price,
                    Discount = discountValue,
                    IsPercent = isPercent,
                    TotalPrice = finalPrice
                });
            }

            return result;
        }

        public async Task<CartViewDTO?> GetByIdAsync(int cartId)
        {
            var cart = await _context.Store_Cart.FindAsync(cartId);
            if (cart == null) return null;

            var game = await _gamesRepo.GetByIdAsync(cart.GameID);
            if (game == null) return null;

            var discount = game.ActiveDiscounts.FirstOrDefault();
            var discountValue = discount?.Value ?? 0;
            var isPercent = discount?.IsPercent ?? false;
            var finalPrice = isPercent ? game.Price * (1 - (discountValue / 100)) : game.Price - discountValue;

            return new CartViewDTO
            {
                ID = cart.ID,
                UserID = cart.UserID,
                GameID = cart.GameID,
                GameName = game.Title,
                Price = game.Price,
                Discount = discountValue,
                IsPercent = isPercent,
                TotalPrice = finalPrice
            };
        }

        public async Task<IEnumerable<CartViewDTO>> GetByUserIdAsync(string userId)
        {
            var carts = await _context.Store_Cart
                .Where(c => c.UserID == userId)
                .ToListAsync();

            var result = new List<CartViewDTO>();

            foreach (var cart in carts)
            {
                var game = await _gamesRepo.GetByIdAsync(cart.GameID);
                if (game == null) continue;

                var discount = game.ActiveDiscounts.FirstOrDefault();
                var discountValue = discount?.Value ?? 0;
                var isPercent = discount?.IsPercent ?? false;
                var finalPrice = isPercent ? game.Price * (1 - (discountValue / 100)) : game.Price - discountValue;

                result.Add(new CartViewDTO
                {
                    ID = cart.ID,
                    UserID = cart.UserID,
                    GameID = cart.GameID,
                    Price = game.Price,
                    Discount = discountValue,
                    IsPercent = isPercent,
                    TotalPrice = finalPrice
                });
            }

            return result;
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
