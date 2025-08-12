using BusinessModel.Model;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IGamesReviewRepository
    {
        Task<IEnumerable<GamesReviewDTOReadOnly>> GetAllAsync();
        Task<GamesReviewDTOReadOnly> GetByIdAsync(int id);
        Task<IEnumerable<GamesReviewDTOReadOnly>> GetByGameIdAsync(int gameId);
        Task<IEnumerable<GamesReviewDTOReadOnly>> GetByUserIdAsync(string userId);
        Task AddAsync(GamesReview review);
        Task UpdateAsync(GamesReview review);
        Task DeleteAsync(int id);
    }
}
