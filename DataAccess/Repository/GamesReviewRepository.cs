using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GamesReviewRepository : IGamesReviewRepository
    {
        private readonly DBContext _context;

        public GamesReviewRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GamesReviewDTOReadOnly>> GetAllAsync()
        {
            return await _context.Games_Reviews
                .Join(
                    _context.Users,
                    review => review.UserID,
                    user => user.Id,
                    (review, user) => new { review, user }
                )
                .GroupJoin(
                    _context.System_ProfilePictures,
                    ru => ru.user.Id,
                    pic => pic.UserId,
                    (ru, pics) => new { ru.review, ru.user, pic = pics.FirstOrDefault() }
            )
                .Select(x => new GamesReviewDTOReadOnly
                {
                    ID = x.review.ID,
                    GameID = x.review.GameID,
                    UserID = x.review.UserID,
                    UserName = x.user.UserName,
                    ProfilePicture = x.pic != null ? x.pic.ImageUrl : null,
                    IsUpvoted = x.review.IsUpvoted,
                    Comment = x.review.Comment,
                    CreatedAt = x.review.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<GamesReviewDTOReadOnly?> GetByIdAsync(int id)
        {
            return await _context.Games_Reviews
                .Where(r => r.ID == id)
                .Join(
                    _context.Users,
                    review => review.UserID,
                    user => user.Id,
                    (review, user) => new { review, user }
                )
                .GroupJoin(
                    _context.System_ProfilePictures,
                    ru => ru.user.Id,
                    pic => pic.UserId,
                    (ru, pics) => new { ru.review, ru.user, pic = pics.FirstOrDefault() }
            )
                .Select(x => new GamesReviewDTOReadOnly
                {
                    ID = x.review.ID,
                    GameID = x.review.GameID,
                    UserID = x.review.UserID,
                    UserName = x.user.UserName,
                    ProfilePicture = x.pic != null ? x.pic.ImageUrl : null,
                    IsUpvoted = x.review.IsUpvoted,
                    Comment = x.review.Comment,
                    CreatedAt = x.review.CreatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<GamesReviewDTOReadOnly>> GetByGameIdAsync(int gameId)
        {
            return await _context.Games_Reviews
                .Where(r => r.GameID == gameId)
                .Join(
                    _context.Users,
                    review => review.UserID,
                    user => user.Id,
                    (review, user) => new { review, user }
                )
                .GroupJoin(
                    _context.System_ProfilePictures,
                    ru => ru.user.Id,
                    pic => pic.UserId,
                    (ru, pics) => new { ru.review, ru.user, pic = pics.FirstOrDefault() }
            )
                .Select(x => new GamesReviewDTOReadOnly
                {
                    ID = x.review.ID,
                    GameID = x.review.GameID,
                    UserID = x.review.UserID,
                    UserName = x.user.UserName,
                    ProfilePicture = x.pic != null ? x.pic.ImageUrl : null,
                    IsUpvoted = x.review.IsUpvoted,
                    Comment = x.review.Comment,
                    CreatedAt = x.review.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<GamesReviewDTOReadOnly>> GetByUserIdAsync(string userId)
        {
            return await _context.Games_Reviews
                .Where(r => r.UserID == userId)
                .Join(
                    _context.Users,
                    review => review.UserID,
                    user => user.Id,
                    (review, user) => new { review, user }
                )
                .GroupJoin(
                    _context.System_ProfilePictures,
                    ru => ru.user.Id,
                    pic => pic.UserId,
                    (ru, pics) => new { ru.review, ru.user, pic = pics.FirstOrDefault() }
            )
                .Select(x => new GamesReviewDTOReadOnly
                {
                    ID = x.review.ID,
                    GameID = x.review.GameID,
                    UserID = x.review.UserID,
                    UserName = x.user.UserName,
                    ProfilePicture = x.pic != null ? x.pic.ImageUrl : null,
                    IsUpvoted = x.review.IsUpvoted,
                    Comment = x.review.Comment,
                    CreatedAt = x.review.CreatedAt
                })
                .ToListAsync();
        }

        public async Task AddAsync(GamesReview review)
        {
            _context.Games_Reviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GamesReview review)
        {
            _context.Games_Reviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var review = await _context.Games_Reviews.FindAsync(id);
            if (review != null)
            {
                _context.Games_Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }
    }
}
