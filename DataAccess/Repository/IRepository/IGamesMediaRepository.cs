using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IGamesMediaRepository
    {
        Task<IEnumerable<GamesMedia>> GetAllAsync();
        Task<GamesMedia> GetByIdAsync(int id);
        Task AddAsync(GamesMedia gameMedia);
        Task UpdateAsync(GamesMedia gameMedia);
        Task DeleteAsync(int id);
    }

}
