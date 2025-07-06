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
    }
}

