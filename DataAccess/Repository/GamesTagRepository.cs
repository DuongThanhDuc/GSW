using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class GamesTagRepository : IGamesTagRepository
    {
        private readonly DBContext _context;
        public GamesTagRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GamesTag>> GetAllAsync()
            => await _context.Games_Tags
                .Include(x => x.Game)
                .Include(x => x.Tag)
                .ToListAsync();

        public async Task<GamesTag?> GetByIdAsync(int id)
            => await _context.Games_Tags
                .Include(x => x.Game)
                .Include(x => x.Tag)
                .FirstOrDefaultAsync(x => x.ID == id);

        public async Task<GamesTag> AddAsync(GamesTag entity)
        {
            _context.Games_Tags.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<GamesTag?> UpdateAsync(int id, GamesTag entity)
        {
            var item = await _context.Games_Tags.FindAsync(id);
            if (item == null) return null;
            item.GameID = entity.GameID;
            item.TagID = entity.TagID;
            item.CreatedBy = entity.CreatedBy;
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Games_Tags.FindAsync(id);
            if (item == null) return false;
            _context.Games_Tags.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
