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

        // Lấy thông tin game 
        public GamesInfoDTO GetGameInfoWithMedia(int gameId)
        {
            var game = _context.Games_Info.FirstOrDefault(g => g.Id == gameId);
            if (game == null) return null;

            // Lấy media liên quan tới game
            var mediaList = _context.Games_Media
                                    .Where(m => m.GameID == gameId)
                                    .ToList();

            return new GamesInfoDTO
            {
                ID = game.Id,
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
                
            };
        }

        public void AddMediaToGame(int gameId, GamesMediaDTO mediaDto)
        {
            var newMedia = new GamesMedia
            {
                GameID = gameId,
                MediaURL = mediaDto.MediaURL,
                MediaType = mediaDto.MediaType
            };
            _context.Games_Media.Add(newMedia);
            _context.SaveChanges();
        }

        public void UpdateMediaInGame(int gameId, GamesMediaDTO mediaDto)
        {
            var media = _context.Games_Media.FirstOrDefault(m => m.Id == mediaDto.Id && m.GameID == gameId);
            if (media != null)
            {
                media.MediaURL = mediaDto.MediaURL;
                media.MediaType = mediaDto.MediaType;
                _context.SaveChanges();
            }
        }

        public void DeleteMediaFromGame(int gameId, int mediaId)
        {
            var media = _context.Games_Media.FirstOrDefault(m => m.Id == mediaId && m.GameID == gameId);
            if (media != null)
            {
                _context.Games_Media.Remove(media);
                _context.SaveChanges();
            }
        }

        public GamesMedia? GetMediaById(int mediaId)
        {
            return _context.Games_Media.FirstOrDefault(m => m.Id == mediaId);
        }
    }

}
