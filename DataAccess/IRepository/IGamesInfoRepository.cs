using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel.Model;
using DataAccess.DTOs;

namespace DataAccess.IRepository
{
    public interface IGamesInfoRepository
    {
        Task<IEnumerable<GamesInfo>> GetAllAsyncOriginal(); 
        Task<GamesInfo?> GetByIdAsyncOriginal(int id);       
        Task<IEnumerable<GamesInfoDTO>> GetAllAsync();
        Task<GamesInfoDTO?> GetByIdAsync(int id);
        Task<GamesInfoDTO> CreateAsync(GamesInfoDTO dto);
        Task<bool> UpdateAsync(GamesInfoDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
