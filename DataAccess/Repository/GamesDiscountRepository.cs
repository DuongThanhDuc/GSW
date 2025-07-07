using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.IRepository;

namespace DataAccess.Repository
{
    public class GamesDiscountRepository : IGamesDiscountRepository
    {
        private readonly DBContext _context;
        public GamesDiscountRepository(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<GamesDiscount> GetAll()
        {
            return _context.Games_Discount.OrderByDescending(x => x.CreatedAt).ToList();
        }

        public GamesDiscount Get(int id)
        {
            return _context.Games_Discount.FirstOrDefault(d => d.Id == id);
        }

        public GamesDiscount Create(GamesDiscount entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            _context.Games_Discount.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public GamesDiscount Update(int id, GamesDiscount entity)
        {
            var discount = _context.Games_Discount.FirstOrDefault(d => d.Id == id);
            if (discount == null) return null;
            discount.Code = entity.Code;
            discount.Description = entity.Description;
            discount.Value = entity.Value;
            discount.IsPercent = entity.IsPercent;
            discount.StartDate = entity.StartDate;
            discount.EndDate = entity.EndDate;
            discount.IsActive = entity.IsActive;
            _context.SaveChanges();
            return discount;
        }

        public void Delete(int id)
        {
            var discount = _context.Games_Discount.FirstOrDefault(d => d.Id == id);
            if (discount == null) return;
            _context.Games_Discount.Remove(discount);
            _context.SaveChanges();
        }

        public bool IsCodeExist(string code, int? ignoreId = null)
        {
            return _context.Games_Discount.Any(x => x.Code == code && (!ignoreId.HasValue || x.Id != ignoreId));
        }

        // NEW: Get discount theo game
        public IEnumerable<GamesDiscount> GetByGameId(int gameId)
        {
            var discountIds = _context.Games_InfoDiscounts
                .Where(x => x.GamesInfoId == gameId)
                .Select(x => x.GamesDiscountId)
                .ToList();

            return _context.Games_Discount
                .Where(d => discountIds.Contains(d.Id))
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
        }

        // NEW: Gán discount cho game
        public void AddDiscountToGame(int gameId, int discountId)
        {
            var exist = _context.Games_InfoDiscounts.Any(x => x.GamesInfoId == gameId && x.GamesDiscountId == discountId);
            if (!exist)
            {
                var link = new GamesInfoDiscount { GamesInfoId = gameId, GamesDiscountId = discountId };
                _context.Games_InfoDiscounts.Add(link);
                _context.SaveChanges();
            }
        }

        // NEW: Bỏ discount khỏi game
        public void RemoveDiscountFromGame(int gameId, int discountId)
        {
            var link = _context.Games_InfoDiscounts.FirstOrDefault(x => x.GamesInfoId == gameId && x.GamesDiscountId == discountId);
            if (link != null)
            {
                _context.Games_InfoDiscounts.Remove(link);
                _context.SaveChanges();
            }
        }
    }
}

