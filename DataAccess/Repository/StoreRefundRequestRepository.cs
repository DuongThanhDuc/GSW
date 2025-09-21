using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    using BusinessModel.Model;
    using DataAccess.Repository.IRepository;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace Data.Repository
    {
        public class StoreRefundRequestRepository : IStoreRefundRequestRepository
        {
            private readonly DBContext _context;

            public StoreRefundRequestRepository(DBContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<StoreRefundRequest>> GetAllAsync()
            {
                return await _context.Store_RefundRequests
                    .Include(r => r.Order)
                    .ToListAsync();
            }

            public async Task<StoreRefundRequest> GetByIdAsync(int id)
            {
                return await _context.Store_RefundRequests
                    .Include(r => r.Order)
                    .FirstOrDefaultAsync(r => r.ID == id);
            }

            public async Task AddAsync(StoreRefundRequest entity)
            {
                _context.Store_RefundRequests.Add(entity);

                StoreOrder o = _context.Store_Orders.Find(entity.OrderID);
                if (o != null)
                {
                    o.Status = "await";
                }
                await _context.SaveChangesAsync();

            }

            public async Task UpdateAsync(StoreRefundRequest entity)
            {
                _context.Store_RefundRequests.Update(entity);
                await _context.SaveChangesAsync();
            }

            public async Task DeleteAsync(int id)
            {
                var entity = await _context.Store_RefundRequests.FindAsync(id);
                if (entity != null)
                {
                    _context.Store_RefundRequests.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }

}
