using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IStoreThreadRepository
    {
        Task<IEnumerable<StoreThreadDTO>> GetAllAsync();
        Task<StoreThreadDTO?> GetByIdAsync(int id);
        Task<StoreThreadDTO> CreateAsync(StoreThreadDTO dto);
        Task<bool> UpdateAsync(StoreThreadDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
