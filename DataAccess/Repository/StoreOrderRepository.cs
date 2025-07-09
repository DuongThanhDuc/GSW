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
    public class StoreOrderRepository : IStoreOrderRepository
    {
        private readonly DBContext _context;

        public StoreOrderRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StoreOrderDTOReadOnly>> GetAllAsync()
        {
            return await _context.Store_Orders
                .Include(o => o.OrderDetails)
                .Select(o => new StoreOrderDTOReadOnly
                {
                    ID = o.ID,
                    UserID = o.UserID,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status,
                    OrderDetails = o.OrderDetails.Select(d => new StoreOrderDetailDTO
                    {
                        ID = d.ID,
                        OrderID = d.OrderID,
                        GameID = d.GameID,
                        UnitPrice = d.UnitPrice,
                        CreatedAt = d.CreatedAt
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<StoreOrderDTOReadOnly?> GetByIdAsync(int id)
        {
            return await _context.Store_Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.ID == id)
                .Select(o => new StoreOrderDTOReadOnly
                {
                    ID = o.ID,
                    UserID = o.UserID,
                    OrderDate = o.OrderDate,
                    TotalAmount = o.TotalAmount,
                    Status = o.Status,
                    OrderDetails = o.OrderDetails.Select(d => new StoreOrderDetailDTO
                    {
                        ID = d.ID,
                        OrderID = d.OrderID,
                        GameID = d.GameID,
                        UnitPrice = d.UnitPrice,
                        CreatedAt = d.CreatedAt
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<StoreOrder> CreateAsync(StoreOrderDTO dto)
        {
            var order = new StoreOrder
            {
                UserID = dto.UserID,
                OrderDate = dto.OrderDate == default ? DateTime.Now : dto.OrderDate,
                TotalAmount = dto.TotalAmount,
                Status = dto.Status ?? "COMPLETED",
                CreatedAt = DateTime.Now
            };

            _context.Store_Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }



        public async Task<bool> UpdateAsync(int id, StoreOrderDTO dto)
        {
            var existingOrder = await _context.Store_Orders.FindAsync(id);
            if (existingOrder == null)
                return false;

            existingOrder.UserID = dto.UserID;
            existingOrder.TotalAmount = dto.TotalAmount;
            existingOrder.Status = dto.Status;
            existingOrder.OrderDate = dto.OrderDate;
            existingOrder.CreatedAt = dto.CreatedAt;

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _context.Store_Orders.FindAsync(id);
            if (order == null)
                return false;

            _context.Store_Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
