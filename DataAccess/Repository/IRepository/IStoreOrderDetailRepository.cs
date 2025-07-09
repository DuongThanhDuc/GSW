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
        Task<IEnumerable<StoreOrderDetailDTO>> GetAllAsync();
        Task<StoreOrderDetailDTO?> GetByIdAsync(int id);
        Task<StoreOrderDetail> CreateAsync(StoreOrderDetailDTO dto);
        Task<bool> UpdateAsync(int id, StoreOrderDetailDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
