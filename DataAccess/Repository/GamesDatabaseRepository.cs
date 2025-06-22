using BusinessModel.Model;
using DataAccess.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GamesDatabaseRepository
    {
        private readonly DBContext _context;

        public GamesDatabaseRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GameDatabase>> GetAllAsync()
        {
            return await _context.Game_Database.ToListAsync();
        }

        public async Task<GameDatabase> GetByIdAsync(int id)
        {
            return await _context.Game_Database.FindAsync(id);
           
        }

        public async Task<GamesDatabaseDTO> CreateAsync(GamesDatabaseDTO dto)
        {
            var newEntry = new GameDatabase
            {
                GameId = dto.GameId,
                GameFilePathURL = dto.GameFilePathURL,
                CreatedAt = DateTime.UtcNow
            };

            _context.Game_Database.Add(newEntry);
            await _context.SaveChangesAsync();

            dto.Id = newEntry.Id;
            dto.CreatedAt = newEntry.CreatedAt;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entry = await _context.Game_Database.FindAsync(id);
            if (entry == null) return false;

            _context.Game_Database.Remove(entry);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
