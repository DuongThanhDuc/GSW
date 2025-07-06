using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GamesBannerRepository : IGamesBannerRepository
    {
        private readonly DBContext _context;

        public GamesBannerRepository(DBContext context)
        {
            _context = context;
        }

        public void CreateBanner(GamesBannerDTO dto)
        {
            var banner = new GamesBanner
            {
                Title = dto.Title,
                ImageUrl = dto.ImageUrl,
                Link = dto.Link,
                IsActive = dto.IsActive
            };
            _context.Games_Banner.Add(banner);
            _context.SaveChanges();
        }

        public void UpdateBanner(int id, GamesBannerDTO dto)
        {
            var banner = _context.Games_Banner.FirstOrDefault(b => b.Id == id);
            if (banner != null)
            {
                banner.Title = dto.Title;
                banner.ImageUrl = dto.ImageUrl;
                banner.Link = dto.Link;
                banner.IsActive = dto.IsActive;
                _context.SaveChanges();
            }
        }

        public void DeleteBanner(int id)
        {
            var banner = _context.Games_Banner.FirstOrDefault(b => b.Id == id);
            if (banner != null)
            {
                _context.Games_Banner.Remove(banner);
                _context.SaveChanges();
            }
        }

        public GamesBannerDTO GetBannerById(int id)
        {
            var banner = _context.Games_Banner.FirstOrDefault(b => b.Id == id);
            if (banner == null) return null;

            return new GamesBannerDTO
            {
                Id = banner.Id,
                Title = banner.Title,
                ImageUrl = banner.ImageUrl,
                Link = banner.Link,
                IsActive = banner.IsActive
            };
        }

        public IEnumerable<GamesBannerDTO> GetAllBanners()
        {
            return _context.Games_Banner.Select(b => new GamesBannerDTO
            {
                Id = b.Id,
                Title = b.Title,
                ImageUrl = b.ImageUrl,
                Link = b.Link,
                IsActive = b.IsActive
            }).ToList();
        }
    }
}
