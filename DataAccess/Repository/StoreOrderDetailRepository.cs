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
    public class StoreOrderDetailRepository : IStoreOrderDetailRepository
    {
        private readonly DBContext _context;

        public StoreOrderDetailRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StoreOrderDetailDTOReadOnly>> GetAllAsync()
        {
            return await _context.Store_OrderDetails
                .Include(d => d.Game)
                .Select(d => new StoreOrderDetailDTOReadOnly
                {
                    ID = d.ID,
                    OrderID = d.OrderID,
                    GameID = d.GameID,
                    GameName = d.Game.Title,
                    GamePicture=d.Game.CoverImagePath,
                    UnitPrice = d.UnitPrice,
                    CreatedAt = d.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<StoreOrderDetailDTOReadOnly?> GetByIdAsync(int id)
        {
            return await _context.Store_OrderDetails
                .Include(d => d.Game)
                .Where(d => d.ID == id)
                .Select(d => new StoreOrderDetailDTOReadOnly
                {
                    ID = d.ID,
                    OrderID = d.OrderID,
                    GameID = d.GameID,
                    GameName = d.Game.Title,
                    GamePicture = d.Game.CoverImagePath,
                    UnitPrice = d.UnitPrice,
                    CreatedAt = d.CreatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<StoreOrderDetail> CreateAsync(StoreOrderDetailDTO dto)
        {
            var detail = new StoreOrderDetail
            {
                OrderID = dto.OrderID,
                GameID = dto.GameID,
                UnitPrice = dto.UnitPrice,
                CreatedAt = dto.CreatedAt
            };

            _context.Store_OrderDetails.Add(detail);
            await _context.SaveChangesAsync();
            return detail;
        }

        public async Task<bool> UpdateAsync(int id, StoreOrderDetailDTO dto)
        {
            var detail = await _context.Store_OrderDetails.FindAsync(id);
            if (detail == null)
                return false;

            detail.OrderID = dto.OrderID;
            detail.GameID = dto.GameID;
            detail.UnitPrice = dto.UnitPrice;
            detail.CreatedAt = dto.CreatedAt;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var detail = await _context.Store_OrderDetails.FindAsync(id);
            if (detail == null)
                return false;

            _context.Store_OrderDetails.Remove(detail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
