using BusinessModel.Model;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IStoreCartRepository
    {
        Task<IEnumerable<StoreCart>> GetAllAsyncOriginal();
        Task<StoreCart?> GetByIdAsyncOriginal(int id);
        Task<IEnumerable<CartDTO>> GetAllAsync();
        Task<CartDTO?> GetByIdAsync(int id);
        Task<CartDTO> CreateAsync(CartDTO dto);
        Task<bool> UpdateAsync(CartDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
