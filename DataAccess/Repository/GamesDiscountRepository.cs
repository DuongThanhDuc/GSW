using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

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

        // Lấy discount hiện tại đang active cho game
        public GamesDiscount GetActiveDiscountByGameId(int gameId)
        {
            var discountId = _context.Games_InfoDiscounts
                .Where(x => x.GamesInfoId == gameId)
                .Select(x => x.GamesDiscountId)
                .ToList()
                .Select(did => _context.Games_Discount.FirstOrDefault(gd => gd.Id == did && gd.IsActive))
                .Where(d => d != null)
                .OrderByDescending(d => d.CreatedAt)
                .Select(d => d.Id)
                .FirstOrDefault();

            if (discountId == 0) return null;
            return _context.Games_Discount.FirstOrDefault(d => d.Id == discountId);
        }

        // Chỉ gán 1 discount active, deactive discount cũ, tạo liên kết mới
        public void SetDiscountForGame(int gameId, int discountId)
        {
            // 1. Lấy các discount hiện tại (cũ) của game (qua bảng liên kết)
            var linkDiscountIds = _context.Games_InfoDiscounts
                .Where(x => x.GamesInfoId == gameId)
                .Select(x => x.GamesDiscountId)
                .ToList();

            // 2. Deactive toàn bộ discount đang liên kết (nếu có)
            if (linkDiscountIds.Any())
            {
                var discounts = _context.Games_Discount.Where(d => linkDiscountIds.Contains(d.Id)).ToList();
                foreach (var d in discounts)
                    d.IsActive = false;
                _context.SaveChanges();
            }

            // 3. Xóa toàn bộ liên kết cũ (không xóa record discount)
            var oldLinks = _context.Games_InfoDiscounts
                .Where(x => x.GamesInfoId == gameId)
                .ToList();
            if (oldLinks.Any())
            {
                _context.Games_InfoDiscounts.RemoveRange(oldLinks);
                _context.SaveChanges();
            }

            // 4. Gán liên kết discount mới, set IsActive = true
            var discount = _context.Games_Discount.FirstOrDefault(d => d.Id == discountId);
            if (discount != null)
            {
                discount.IsActive = true;
                _context.SaveChanges();

                // Gán liên kết mới
                var exist = _context.Games_InfoDiscounts.Any(x => x.GamesInfoId == gameId && x.GamesDiscountId == discountId);
                if (!exist)
                {
                    var link = new GamesInfoDiscount { GamesInfoId = gameId, GamesDiscountId = discountId };
                    _context.Games_InfoDiscounts.Add(link);
                    _context.SaveChanges();
                }
            }
        }

        // Xóa liên kết discount khỏi game (không deactive discount, chỉ bỏ liên kết)
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

