using BusinessModel.Model;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GamesReviewRepository : IGamesReviewRepository
    {
        private readonly DBContext _context;

        public GamesReviewRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GamesReview>> GetAllAsync()
        {
            return await _context.Games_Reviews
                .Include(r => r.Game)
                .ToListAsync();
        }

        public async Task<GamesReview> GetByIdAsync(int id)
        {
            return await _context.Games_Reviews
                .Include(r => r.Game)
                .FirstOrDefaultAsync(r => r.ID == id);
        }

        public async Task<IEnumerable<GamesReview>> GetByGameIdAsync(int gameId)
        {
            return await _context.Games_Reviews
                .Where(r => r.GameID == gameId)
                .Include(r => r.Game)
                .ToListAsync();
        }

        public async Task<IEnumerable<GamesReview>> GetByUserIdAsync(string userId)
        {
            return await _context.Games_Reviews
                .Where(r => r.UserID == userId)
                .Include(r => r.Game)
                .ToListAsync();
        }

        public async Task AddAsync(GamesReview review)
        {
            _context.Games_Reviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GamesReview review)
        {
            _context.Games_Reviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var review = await _context.Games_Reviews.FindAsync(id);
            if (review != null)
            {
                _context.Games_Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }
    }
}
