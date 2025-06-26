using BusinessModel.Model;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GamesMediaRepository : IGamesMediaRepository
    {
        private readonly DBContext _context;
        public GamesMediaRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GamesMedia>> GetAllAsync()
        {
            return await _context.Games_Media.ToListAsync();
        }
        public async Task<GamesMedia> GetByIdAsync(int id)
        {
            return await _context.Games_Media.FindAsync(id);
        }
        public async Task AddAsync(GamesMedia gameMedia)
        {
            _context.Games_Media.Add(gameMedia);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(GamesMedia gameMedia)
        {
            _context.Games_Media.Update(gameMedia);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Games_Media.FindAsync(id);
            if (entity != null)
            {
                _context.Games_Media.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

}
