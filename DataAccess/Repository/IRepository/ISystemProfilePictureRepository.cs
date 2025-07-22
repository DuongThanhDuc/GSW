using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface ISystemProfilePictureRepository
    {
        Task<SystemProfilePictureDTO?> GetByUserIdAsync(string userId);
        Task<IEnumerable<SystemProfilePictureDTO>> GetAllAsync();
        Task AddAsync(SystemProfilePictureDTO dto);
        Task UpdateAsync(SystemProfilePictureDTO dto);
        Task DeleteAsync(string userId);
        Task CreateOrUpdateAsync(SystemProfilePictureDTO dto);
    }
}
