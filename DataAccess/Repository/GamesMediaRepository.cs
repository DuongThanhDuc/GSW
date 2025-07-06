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
    public class GamesMediaRepository : IGamesMediaRepository
    {
        private readonly DBContext _context;

        public GamesMediaRepository(DBContext context)
        {
            _context = context;
        }

        // Lấy thông tin game + media
        public GamesInfoDTO GetGameInfoWithMedia(int gameId)
        {
            var game = _context.Games_Info.FirstOrDefault(g => g.ID == gameId);
            if (game == null) return null;

            // Lấy media liên quan tới game
            var mediaList = _context.Games_Media
                                    .Where(m => m.GameId == gameId)
                                    .ToList();

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
                CreatedBy = game.CreatedBy,
                IsActive = game.IsActive,
                Media = mediaList.Select(m => new GamesMediaDTO
                {
                    Id = m.Id,
                    GameId = m.GameId,
                    MediaURL = m.MediaURL
                }).ToList()
            };
        }

        public void AddMediaToGame(int gameId, GamesMediaDTO mediaDto)
        {
            var newMedia = new GamesMedia
            {
                GameId = gameId,
                MediaURL = mediaDto.MediaURL
            };
            _context.Games_Media.Add(newMedia);
            _context.SaveChanges();
        }

        public void UpdateMediaInGame(int gameId, GamesMediaDTO mediaDto)
        {
            var media = _context.Games_Media.FirstOrDefault(m => m.Id == mediaDto.Id && m.GameId == gameId);
            if (media != null)
            {
                media.MediaURL = mediaDto.MediaURL;
                _context.SaveChanges();
            }
        }

        public void DeleteMediaFromGame(int gameId, int mediaId)
        {
            var media = _context.Games_Media.FirstOrDefault(m => m.Id == mediaId && m.GameId == gameId);
            if (media != null)
            {
                _context.Games_Media.Remove(media);
                _context.SaveChanges();
            }
        }
    }

}
