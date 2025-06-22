using BusinessModel.Model;
using DataAccess.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface ISystemMediaRepository
    {
        Task<SystemMediaDTO> SaveMediaUrlAsync(string mediaUrl);
        Task<SystemMedia> GetByIdAsync(int id);
        Task<IEnumerable<SystemMedia>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}
