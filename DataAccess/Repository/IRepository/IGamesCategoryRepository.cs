using BusinessModel.Model;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.IRepository
{
    public interface IGamesCategoryRepository
    {
        Task<IEnumerable<GamesCategory>> GetAllAsync();
        Task<GamesCategory?> GetByIdAsync(int id);
        Task<GamesCategory> AddAsync(GamesCategory entity);
        Task<GamesCategory?> UpdateAsync(int id, GamesCategory entity);
        Task<bool> DeleteAsync(int id);
    }

}
