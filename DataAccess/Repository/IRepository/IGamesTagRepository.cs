using BusinessModel.Model;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IGamesTagRepository
    {
        Task<IEnumerable<GamesTag>> GetAllAsync();
        Task<GamesTag?> GetByIdAsync(int id);
        Task<GamesTag> AddAsync(GamesTag entity);
        Task<GamesTag?> UpdateAsync(int id, GamesTag entity);
        Task<bool> DeleteAsync(int id);
    }
}
