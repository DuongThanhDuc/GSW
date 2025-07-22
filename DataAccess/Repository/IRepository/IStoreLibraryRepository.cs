using BusinessModel.Model;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IStoreLibraryRepository
    {
        Task<IEnumerable<StoreLibraryDTO>> GetAllAsync();
        Task<StoreLibraryDTO?> GetByIdAsync(int id);
        Task<IEnumerable<StoreLibraryDTO>> GetByUserIdAsync(string userId);
        Task AddAsync(StoreLibraryDTO dto);
        Task UpdateAsync(StoreLibraryDTO dto);
        Task DeleteAsync(int id);
    }
}
