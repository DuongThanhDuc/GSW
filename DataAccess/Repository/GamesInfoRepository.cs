using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // --- Hàm cũ: Trả về GamesInfoDTOReadOnly (nếu muốn trả danh sách discount hoặc nhiều thông tin khác) ---
        public async Task<IEnumerable<GamesInfoDTOReadOnly>> GetAllAsync()
        {
            return await _context.Games_Info
                .Include(g => g.Media)
                .Include(g => g.Reviews)
                .Include(g => g.GamesInfoDiscounts).ThenInclude(d => d.GamesDiscount)
                .Include(g => g.GameTags).ThenInclude(gt => gt.Tag)
                .Include(g => g.GameCategories).ThenInclude(gc => gc.Category)
                .Select(g => new GamesInfoDTOReadOnly
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
                    CreatedBy = g.CreatedBy,

                    Media = g.Media.Select(m => new GamesMediaDTO
                    {
                        Id = m.Id,
                        GameID = m.GameID,
                        MediaURL = m.MediaURL
                    }).ToList(),

                    Reviews = g.Reviews.Select(r => new GamesReviewDTO
                    {
                        ID = r.ID,
                        GameID = r.GameID,
                        UserID = r.UserID,
                        StarCount = r.StarCount,
                        Comment = r.Comment,
                        CreatedAt = r.CreatedAt
                    }).ToList(),

                    ActiveDiscounts = g.GamesInfoDiscounts
                        .Where(d => d.GamesDiscount.IsActive && d.GamesDiscount.StartDate <= DateTime.UtcNow && d.GamesDiscount.EndDate >= DateTime.UtcNow)
                        .Select(d => new GamesDiscountDTO
                        {
                            Id = d.GamesDiscount.Id,
                            Code = d.GamesDiscount.Code,
                            Description = d.GamesDiscount.Description,
                            Value = d.GamesDiscount.Value,
                            IsPercent = d.GamesDiscount.IsPercent,
                            StartDate = d.GamesDiscount.StartDate,
                            EndDate = d.GamesDiscount.EndDate,
                            IsActive = d.GamesDiscount.IsActive,
                            CreatedAt = d.GamesDiscount.CreatedAt
                        }).ToList(),

                    Tags = g.GameTags.Select(gt => new GamesTagDTO
                    {
                        ID = gt.ID,
                        GameID = gt.GameID,
                        TagID = gt.TagID,
                        CreatedAt = gt.CreatedAt,
                        CreatedBy = gt.CreatedBy,
                        GameName = gt.Game.Title,
                        TagName = gt.Tag.TagName
                    }).ToList(),

                    Categories = g.GameCategories.Select(gc => new GamesCategoryDTO
                    {
                        ID = gc.ID,
                        GameID = gc.GameID,
                        CategoryID = gc.CategoryID,
                        CreatedAt = gc.CreatedAt,
                        CreatedBy = gc.CreatedBy,
                        GameName = gc.Game.Title,
                        CategoryName = gc.Category.CategoryName
                    }).ToList()
                })
                .ToListAsync();
        }

        // --- Hàm cũ: GetByIdAsync dạng ReadOnly ---
        public async Task<GamesInfoDTOReadOnly?> GetByIdAsync(int id)
        {
            var g = await _context.Games_Info
                .Include(g => g.Media)
                .Include(g => g.Reviews)
                .Include(g => g.GamesInfoDiscounts).ThenInclude(d => d.GamesDiscount)
                .Include(g => g.GameTags).ThenInclude(gt => gt.Tag)
                .Include(g => g.GameCategories).ThenInclude(gc => gc.Category)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (g == null) return null;

            return new GamesInfoDTOReadOnly
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
                CreatedBy = g.CreatedBy,

                Media = g.Media.Select(m => new GamesMediaDTO
                {
                    Id = m.Id,
                    GameID = m.GameID,
                    MediaURL = m.MediaURL
                }).ToList(),

                Reviews = g.Reviews.Select(r => new GamesReviewDTO
                {
                    ID = r.ID,
                    GameID = r.GameID,
                    UserID = r.UserID,
                    StarCount = r.StarCount,
                    Comment = r.Comment,
                    CreatedAt = r.CreatedAt
                }).ToList(),

                ActiveDiscounts = g.GamesInfoDiscounts
                    .Where(d => d.GamesDiscount.IsActive && d.GamesDiscount.StartDate <= DateTime.UtcNow && d.GamesDiscount.EndDate >= DateTime.UtcNow)
                    .Select(d => new GamesDiscountDTO
                    {
                        Id = d.GamesDiscount.Id,
                        Code = d.GamesDiscount.Code,
                        Description = d.GamesDiscount.Description,
                        Value = d.GamesDiscount.Value,
                        IsPercent = d.GamesDiscount.IsPercent,
                        StartDate = d.GamesDiscount.StartDate,
                        EndDate = d.GamesDiscount.EndDate,
                        IsActive = d.GamesDiscount.IsActive,
                        CreatedAt = d.GamesDiscount.CreatedAt
                    }).ToList(),

                Tags = g.GameTags.Select(gt => new GamesTagDTO
                {
                    ID = gt.ID,
                    GameID = gt.GameID,
                    TagID = gt.TagID,
                    CreatedAt = gt.CreatedAt,
                    CreatedBy = gt.CreatedBy,
                    GameName = gt.Game?.Title,
                    TagName = gt.Tag?.TagName
                }).ToList(),

                Categories = g.GameCategories.Select(gc => new GamesCategoryDTO
                {
                    ID = gc.ID,
                    GameID = gc.GameID,
                    CategoryID = gc.CategoryID,
                    CreatedAt = gc.CreatedAt,
                    CreatedBy = gc.CreatedBy,
                    GameName = gc.Game?.Title,
                    CategoryName = gc.Category?.CategoryName
                }).ToList()
            };
        }

        // --- THÊM MỚI: Trả về GamesInfoDTO có ActiveDiscount (1 trường duy nhất) ---

        public async Task<IEnumerable<GamesInfoDTO>> GetAllDtoWithActiveDiscountAsync()
        {
            var games = await _context.Games_Info
                .Include(g => g.GamesInfoDiscounts).ThenInclude(d => d.GamesDiscount)
                .ToListAsync();

            var now = DateTime.UtcNow;

            return games.Select(g =>
            {
                var activeDiscount = g.GamesInfoDiscounts
                    .Select(d => d.GamesDiscount)
                    .Where(d => d.IsActive && d.StartDate <= now && d.EndDate >= now)
                    .OrderByDescending(d => d.CreatedAt)
                    .FirstOrDefault();

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
                    CreatedBy = g.CreatedBy,
                    IsActive = g.IsActive,
                    ActiveDiscount = activeDiscount == null ? null : new GamesDiscountDTO
                    {
                        Id = activeDiscount.Id,
                        Code = activeDiscount.Code,
                        Description = activeDiscount.Description,
                        Value = activeDiscount.Value,
                        IsPercent = activeDiscount.IsPercent,
                        StartDate = activeDiscount.StartDate,
                        EndDate = activeDiscount.EndDate,
                        IsActive = activeDiscount.IsActive,
                        CreatedAt = activeDiscount.CreatedAt
                    }
                };
            }).ToList();
        }

        public async Task<GamesInfoDTO?> GetDtoByIdWithActiveDiscountAsync(int id)
        {
            var g = await _context.Games_Info
                .Include(g => g.GamesInfoDiscounts).ThenInclude(d => d.GamesDiscount)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (g == null) return null;

            var now = DateTime.UtcNow;
            var activeDiscount = g.GamesInfoDiscounts
                .Select(d => d.GamesDiscount)
                .Where(d => d.IsActive && d.StartDate <= now && d.EndDate >= now)
                .OrderByDescending(d => d.CreatedAt)
                .FirstOrDefault();

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
                CreatedBy = g.CreatedBy,
                IsActive = g.IsActive,
                ActiveDiscount = activeDiscount == null ? null : new GamesDiscountDTO
                {
                    Id = activeDiscount.Id,
                    Code = activeDiscount.Code,
                    Description = activeDiscount.Description,
                    Value = activeDiscount.Value,
                    IsPercent = activeDiscount.IsPercent,
                    StartDate = activeDiscount.StartDate,
                    EndDate = activeDiscount.EndDate,
                    IsActive = activeDiscount.IsActive,
                    CreatedAt = activeDiscount.CreatedAt
                }
            };
        }

        // --- Hàm lấy theo entity model, trả về entity (không phải DTO) ---
        public GamesInfo GetByIdWithActiveDiscount(int gameId)
        {
            var game = _context.Games_Info
                .Include(g => g.GamesInfoDiscounts)
                .ThenInclude(gid => gid.GamesDiscount)
                .FirstOrDefault(g => g.Id == gameId);

            if (game == null) return null;

            var now = DateTime.UtcNow;
            var activeDiscount = game.GamesInfoDiscounts?
                .Select(x => x.GamesDiscount)
                .Where(d => d.IsActive && d.StartDate <= now && d.EndDate >= now)
                .OrderByDescending(d => d.CreatedAt)
                .FirstOrDefault();

            game.ActiveDiscount = activeDiscount;
            return game;
        }

        // Các hàm CRUD khác (GIỮ NGUYÊN)
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
    }
}
