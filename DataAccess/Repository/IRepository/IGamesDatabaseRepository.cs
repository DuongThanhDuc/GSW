using BusinessModel.Model;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IGamesDatabaseRepository
    {
        Task<IEnumerable<GameDatabase>> GetAllAsync();
        Task<GameDatabase> GetByIdAsync(int id);
        Task<GamesDatabaseDTO> CreateAsync(GamesDatabaseDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
