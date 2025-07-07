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
    public class GamesInfoRepository : IGamesInfoRepository
    {
        private readonly DBContext _context;

        public GamesInfoRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GamesInfo>> GetAllAsyncOriginal()
        {
            return await _context.Games_Info.ToListAsync();
        }

        public async Task<GamesInfo?> GetByIdAsyncOriginal(int id)
        {
            return await _context.Games_Info.FindAsync(id);
        }

        public async Task<IEnumerable<GamesInfoDTO>> GetAllAsync()
        {
            return await _context.Games_Info
                .Select(g => new GamesInfoDTO
                {
                    ID = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    Price = g.Price,
                    Genre = g.Genre,
                    DeveloperId = g.DeveloperId,
                    InstallerFilePath = g.InstallerFilePath,
                    CoverImagePath = g.CoverImagePath,
                    Status = g.Status,
                    IsActive = g.IsActive,
                    CreatedBy = g.CreatedBy
                })
                .ToListAsync();
        }

        // Lấy game dạng DTO theo ID (không có media, không có discount)
        public async Task<GamesInfoDTO?> GetByIdAsync(int id)
        {
            var g = await _context.Games_Info
                .FirstOrDefaultAsync(x => x.Id == id);
            if (g == null) return null;

            return new GamesInfoDTO
            {
                ID = g.Id,
                Title = g.Title,
                Description = g.Description,
                Price = g.Price,
                Genre = g.Genre,
                DeveloperId = g.DeveloperId,
                InstallerFilePath = g.InstallerFilePath,
                CoverImagePath = g.CoverImagePath,
                Status = g.Status,
                IsActive = g.IsActive,
                CreatedBy = g.CreatedBy
            };
        }

        // Tạo game mới
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
                IsActive = dto.IsActive,
                CreatedBy = dto.CreatedBy
            };
            _context.Games_Info.Add(game);
            await _context.SaveChangesAsync();
            dto.ID = game.Id;
            return dto;
        }

        // Cập nhật game
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
            game.IsActive = dto.IsActive;
            game.CreatedBy = dto.CreatedBy;

            _context.Games_Info.Update(game);
            await _context.SaveChangesAsync();
            return true;
        }

        // Xóa game
        public async Task<bool> DeleteAsync(int id)
        {
            var game = await _context.Games_Info.FindAsync(id);
            if (game == null) return false;
            _context.Games_Info.Remove(game);
            await _context.SaveChangesAsync();
            return true;
        }

        // Kích hoạt/vô hiệu hóa game
        public async Task<bool> SetActiveStatusAsync(int id, bool isActive)
        {
            var game = await _context.Games_Info.FindAsync(id);
            if (game == null) return false;
            game.IsActive = isActive;
            _context.Games_Info.Update(game);
            await _context.SaveChangesAsync();
            return true;
        }

        // Đổi trạng thái game (Status)
        public async Task<bool> UpdateStatusAsync(int id, string status)
        {
            var game = await _context.Games_Info.FindAsync(id);
            if (game == null) return false;
            game.Status = status;
            _context.Games_Info.Update(game);
            await _context.SaveChangesAsync();
            return true;
        }

        // Update bằng entity gốc
        public async Task UpdateAsync(GamesInfo game)
        {
            _context.Games_Info.Update(game);
            await _context.SaveChangesAsync();
        }
    }
   
}

