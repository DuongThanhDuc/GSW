﻿using BusinessModel.Model;
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
                    .ThenInclude(od => od.Game)
                .Join(_context.Users,
                    order => order.UserID,
                    user => user.Id,
                    (order, user) => new StoreOrderDTOReadOnly
                    {
                        ID = order.ID,
                        UserID = order.UserID,
                        UserName = user.UserName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        OrderDate = order.OrderDate,
                        TotalAmount = order.TotalAmount,
                        Status = order.Status,
                        OrderDetails = order.OrderDetails.Select(d => new StoreOrderDetailDTOReadOnly
                        {
                            ID = d.ID,
                            OrderID = d.OrderID,
                            GameID = d.GameID,
                            GameName = d.Game.Title,
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
                    .ThenInclude(od => od.Game)
                .Where(o => o.ID == id)
                .Join(_context.Users,
                    order => order.UserID,
                    user => user.Id,
                    (order, user) => new StoreOrderDTOReadOnly
                    {
                        ID = order.ID,
                        UserID = order.UserID,
                        UserName = user.UserName,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        OrderDate = order.OrderDate,
                        TotalAmount = order.TotalAmount,
                        Status = order.Status,
                        OrderDetails = order.OrderDetails.Select(d => new StoreOrderDetailDTOReadOnly
                        {
                            ID = d.ID,
                            OrderID = d.OrderID,
                            GameID = d.GameID,
                            GameName = d.Game.Title,
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
