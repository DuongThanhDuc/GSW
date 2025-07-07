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
                .Include(g => g.Media)
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
                    IsActive = g.IsActive,
                    CreatedBy = g.CreatedBy,
                    Media = g.Media.Select(m => new GamesMediaDTO
                    {
                        // Map media fields
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<GamesInfoDTO?> GetByIdAsync(int id)
        {
            var g = await _context.Games_Info
                .Include(x => x.Media)
                .FirstOrDefaultAsync(x => x.ID == id);
            if (g == null) return null;

            return new GamesInfoDTO
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
                IsActive = g.IsActive,
                CreatedBy = g.CreatedBy,
                Media = g.Media.Select(m => new GamesMediaDTO
                {
                    // Map media fields
                }).ToList()
            };
        }

        public async Task<GamesInfoDTO> GetByIdWithDiscountsAsync(int id)
        {
            var now = DateTime.Now;
            var g = await _context.Games_Info
                .Include(x => x.Media)
                .Include(x => x.GamesInfoDiscounts)
                    .ThenInclude(gid => gid.GamesDiscount)
                .FirstOrDefaultAsync(x => x.ID == id);
            if (g == null) return null;
            return new GamesInfoDTO
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
                IsActive = g.IsActive,
                CreatedBy = g.CreatedBy,
                Media = g.Media.Select(m => new GamesMediaDTO
                {
                    // Map media fields
                }).ToList(),
                ActiveDiscounts = g.GamesInfoDiscounts
                    .Where(gid => gid.GamesDiscount.IsActive &&
                                  gid.GamesDiscount.StartDate <= now &&
                                  gid.GamesDiscount.EndDate >= now)
                    .Select(gid => new GamesDiscountDTO
                    {
                        Id = gid.GamesDiscount.Id,
                        Code = gid.GamesDiscount.Code,
                        Description = gid.GamesDiscount.Description,
                        Value = gid.GamesDiscount.Value,
                        IsPercent = gid.GamesDiscount.IsPercent,
                        StartDate = gid.GamesDiscount.StartDate,
                        EndDate = gid.GamesDiscount.EndDate,
                        IsActive = gid.GamesDiscount.IsActive,
                        CreatedAt = gid.GamesDiscount.CreatedAt
                    }).ToList()
            };
        }

        public async Task<IEnumerable<GamesInfoDTO>> GetAllWithDiscountsAsync()
        {
            var now = DateTime.Now;
            var list = await _context.Games_Info
                .Include(g => g.Media)
                .Include(g => g.GamesInfoDiscounts)
                    .ThenInclude(gid => gid.GamesDiscount)
                .ToListAsync();

            return list.Select(g => new GamesInfoDTO
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
                IsActive = g.IsActive,
                CreatedBy = g.CreatedBy,
                Media = g.Media.Select(m => new GamesMediaDTO
                {
                    // Map media fields
                }).ToList(),
                ActiveDiscounts = g.GamesInfoDiscounts
                    .Where(gid => gid.GamesDiscount.IsActive &&
                                  gid.GamesDiscount.StartDate <= now &&
                                  gid.GamesDiscount.EndDate >= now)
                    .Select(gid => new GamesDiscountDTO
                    {
                        Id = gid.GamesDiscount.Id,
                        Code = gid.GamesDiscount.Code,
                        Description = gid.GamesDiscount.Description,
                        Value = gid.GamesDiscount.Value,
                        IsPercent = gid.GamesDiscount.IsPercent,
                        StartDate = gid.GamesDiscount.StartDate,
                        EndDate = gid.GamesDiscount.EndDate,
                        IsActive = gid.GamesDiscount.IsActive,
                        CreatedAt = gid.GamesDiscount.CreatedAt
                    }).ToList()
            });
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
                IsActive = dto.IsActive,
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
            game.IsActive = dto.IsActive;
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

        public async Task<bool> SetActiveStatusAsync(int id, bool isActive)
        {
            var game = await _context.Games_Info.FindAsync(id);
            if (game == null) return false;
            game.IsActive = isActive;
            _context.Games_Info.Update(game);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateStatusAsync(int id, string status)
        {
            var game = await _context.Games_Info.FindAsync(id);
            if (game == null) return false;
            game.Status = status;
            _context.Games_Info.Update(game);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateAsync(GamesInfo game)
        {
            _context.Games_Info.Update(game);
            await _context.SaveChangesAsync();
        }

        public async Task AddDiscountToGameAsync(int gameId, int discountId)
        {
            var exist = await _context.Games_InfoDiscounts
                .AnyAsync(x => x.GamesInfoId == gameId && x.GamesDiscountId == discountId);
            if (!exist)
            {
                var entity = new GamesInfoDiscount
                {
                    GamesInfoId = gameId,
                    GamesDiscountId = discountId
                };
                _context.Games_InfoDiscounts.Add(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveDiscountFromGameAsync(int gameId, int discountId)
        {
            var entity = await _context.Games_InfoDiscounts
                .FirstOrDefaultAsync(x => x.GamesInfoId == gameId && x.GamesDiscountId == discountId);
            if (entity != null)
            {
                _context.Games_InfoDiscounts.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
   
}

