using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class StoreLibraryRepository:IStoreLibraryRepository
    {
        private readonly DBContext _context;

        public StoreLibraryRepository(DBContext context)
        {
            _context = context;
        }   

        public async Task<IEnumerable<StoreLibraryDTO>> GetAllAsync()
        {
            return await _context.Store_Library
                .Select(lib => new StoreLibraryDTO
                {
                    ID = lib.ID,
                    UserID = lib.UserID,
                    GamesID = lib.GamesID,
                    CreatedAt = lib.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<StoreLibraryDTO?> GetByIdAsync(int id)
        {
            var lib = await _context.Store_Library.FirstOrDefaultAsync(x => x.ID == id);
            if (lib == null) return null;

            return new StoreLibraryDTO
            {
                ID = lib.ID,
                UserID = lib.UserID,
                GamesID = lib.GamesID,
                CreatedAt = lib.CreatedAt
            };
        }

        public async Task<IEnumerable<StoreLibraryDTO>> GetByUserIdAsync(string userId)
        {
            return await _context.Store_Library
                .Where(x => x.UserID == userId)
                .Select(lib => new StoreLibraryDTO
                {
                    ID = lib.ID,
                    UserID = lib.UserID,
                    GamesID = lib.GamesID,
                    CreatedAt = lib.CreatedAt
                })
                .ToListAsync();
        }

        public async Task AddAsync(StoreLibraryDTO dto)
        {
            var entity = new StoreLibrary
            {
                UserID = dto.UserID,
                GamesID = dto.GamesID,
                CreatedAt = dto.CreatedAt
            };

            await _context.Store_Library.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(StoreLibraryDTO dto)
        {
            var lib = await _context.Store_Library.FirstOrDefaultAsync(x => x.ID == dto.ID);
            if (lib == null) return;

            lib.UserID = dto.UserID;
            lib.GamesID = dto.GamesID;
            lib.CreatedAt = dto.CreatedAt;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lib = await _context.Store_Library.FirstOrDefaultAsync(x => x.ID == id);
            if (lib == null) return;

            _context.Store_Library.Remove(lib);
            await _context.SaveChangesAsync();
        }
    }
}
