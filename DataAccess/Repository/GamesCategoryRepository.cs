using BusinessModel.Model;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repository.IRepository;

namespace DataAccess.Repository
{
    public class GamesCategoryRepository : IGamesCategoryRepository
    {
        private readonly DBContext _context;
        public GamesCategoryRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GamesCategory>> GetAllAsync()
            => await _context.Games_Categories
                .Include(x => x.Game)
                .Include(x => x.Category)
                .ToListAsync();

        public async Task<GamesCategory?> GetByIdAsync(int id)
            => await _context.Games_Categories
                .Include(x => x.Game)
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.ID == id);

        public async Task<GamesCategory> AddAsync(GamesCategory entity)
        {
            _context.Games_Categories.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<GamesCategory?> UpdateAsync(int id, GamesCategory entity)
        {
            var item = await _context.Games_Categories.FindAsync(id);
            if (item == null) return null;
            item.GameID = entity.GameID;
            item.CategoryID = entity.CategoryID;
            item.CreatedBy = entity.CreatedBy;
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Games_Categories.FindAsync(id);
            if (item == null) return false;
            _context.Games_Categories.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
