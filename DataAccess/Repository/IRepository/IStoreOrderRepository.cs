using BusinessModel.Model;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IStoreOrderRepository
    {
        Task<IEnumerable<StoreOrderDTOReadOnly>> GetAllAsync();
        Task<StoreOrderDTOReadOnly?> GetByIdAsync(int id);
        Task<StoreOrder> CreateAsync(StoreOrderDTO dto);
        Task<bool> UpdateAsync(int id, StoreOrderDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateOrderStatusAsync(int id, string status);
    }
}
