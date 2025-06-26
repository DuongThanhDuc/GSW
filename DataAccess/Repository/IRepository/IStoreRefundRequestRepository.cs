using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IStoreRefundRequestRepository
    {
        Task<IEnumerable<StoreRefundRequest>> GetAllAsync();
        Task<StoreRefundRequest> GetByIdAsync(int id);
        Task AddAsync(StoreRefundRequest entity);
        Task UpdateAsync(StoreRefundRequest entity);
        Task DeleteAsync(int id);
    }
}
