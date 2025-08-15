using BusinessModel.Model;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IStoreOrderDetailRepository
    {
        Task<IEnumerable<StoreOrderDetailDTOReadOnly>> GetAllAsync();
        Task<StoreOrderDetailDTOReadOnly?> GetByIdAsync(int id);
        Task<StoreOrderDetail> CreateAsync(StoreOrderDetailDTO dto);
        Task<bool> UpdateAsync(int id, StoreOrderDetailDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<StoreOrderDetailDTOReadOnly>> GetByStoreOrderIdAsync(int storeOrderId);
    }
}
