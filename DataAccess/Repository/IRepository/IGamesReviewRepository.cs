using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IGamesReviewRepository
    {
        Task<IEnumerable<GamesReview>> GetAllAsync();
        Task<GamesReview> GetByIdAsync(int id);
        Task<IEnumerable<GamesReview>> GetByGameIdAsync(int gameId);
        Task<IEnumerable<GamesReview>> GetByUserIdAsync(string userId);
        Task AddAsync(GamesReview review);
        Task UpdateAsync(GamesReview review);
        Task DeleteAsync(int id);
    }
}
