using BusinessModel.Model;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IStoreCartRepository
    {
        Task<CartDTO> CreateAsync(CartDTO dto);
        Task<bool> UpdateAsync(CartDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<CartViewDTO>> GetAllAsync();
        Task<CartViewDTO?> GetByIdAsync(int cartId);
        Task<IEnumerable<CartViewDTO>> GetByUserIdAsync(string userId);
    }
}
