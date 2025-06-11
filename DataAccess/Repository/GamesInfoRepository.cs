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
    public class GamesInfoRepository
    {
        private readonly DBContext _context;

        public GamesInfoRepository(DBContext context)
        {
            _context = context;
        }

        // Return the original model
        public async Task<IEnumerable<GamesInfo>> GetAllAsyncOriginal()
        {
            return await _context.Games_Info.ToListAsync();
        }

        // Return the original model
        public async Task<GamesInfo?> GetByIdAsyncOriginal(int id)
        {
            return await _context.Games_Info.FindAsync(id);
        }

        public async Task<IEnumerable<GamesInfoDTO>> GetAllAsync()
        {
            return await _context.Games_Info
                .Select(g => new GamesInfoDTO
                {
                    ID = g.ID,
                    Title = g.Title,
                    Description = g.Description,
                    Price = g.Price,
                    Genre = g.Genre,
                    DeveloperId = g.DeveloperId,
                    InstallerFilePath = g.InstallerFilePath,
                    CoverImagePath = g.CoverImagePath,
                    Status = g.Status,
                    CreatedBy = g.CreatedBy
                }).ToListAsync();
        }

        public async Task<GamesInfoDTO?> GetByIdAsync(int id)
        {
            var game = await _context.Games_Info.FindAsync(id);
            if (game == null) return null;

            return new GamesInfoDTO
            {
                ID = game.ID,
                Title = game.Title,
                Description = game.Description,
                Price = game.Price,
                Genre = game.Genre,
                DeveloperId = game.DeveloperId,
                InstallerFilePath = game.InstallerFilePath,
                CoverImagePath = game.CoverImagePath,
                Status = game.Status,
                CreatedBy = game.CreatedBy
            };
        }

        public async Task<GamesInfoDTO> CreateAsync(GamesInfoDTO dto)
        {
            var game = new GamesInfo
            {
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                Genre = dto.Genre,
                DeveloperId = dto.DeveloperId,
                InstallerFilePath = dto.InstallerFilePath,
                CoverImagePath = dto.CoverImagePath,
                Status = dto.Status,
                CreatedBy = dto.CreatedBy
            };

            _context.Games_Info.Add(game);
            await _context.SaveChangesAsync();

            dto.ID = game.ID;
            return dto;
        }

        public async Task<bool> UpdateAsync(GamesInfoDTO dto)
        {
            var game = await _context.Games_Info.FindAsync(dto.ID);
            if (game == null) return false;

            game.Title = dto.Title;
            game.Description = dto.Description;
            game.Price = dto.Price;
            game.Genre = dto.Genre;
            game.DeveloperId = dto.DeveloperId;
            game.InstallerFilePath = dto.InstallerFilePath;
            game.CoverImagePath = dto.CoverImagePath;
            game.Status = dto.Status;
            game.CreatedBy = dto.CreatedBy;

            _context.Games_Info.Update(game);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var game = await _context.Games_Info.FindAsync(id);
            if (game == null) return false;

            _context.Games_Info.Remove(game);
            await _context.SaveChangesAsync();
            return true;
        }
    }


}

