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
    public class StoreThreadReplyRepository : IStoreThreadReplyRepository
    {
        private readonly DBContext _context;

        public StoreThreadReplyRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StoreThreadReplyDTOReadOnly>> GetAllAsync()
        {
            return await _context.Store_ThreadReplies
                .Join(
                    _context.Users,
                    reply => reply.CreatedBy,
                    user => user.Id,
                    (reply, user) => new { reply, user }
                )
                .GroupJoin(
                    _context.System_ProfilePictures,
                    ru => ru.user.Id,
                    pic => pic.UserId,
                    (ru, pics) => new { ru.reply, ru.user, pic = pics.FirstOrDefault() }
                )
                .Select(x => new StoreThreadReplyDTOReadOnly
                {
                    Id = x.reply.Id,
                    ThreadID = x.reply.ThreadID,
                    ThreadComment = x.reply.ThreadComment,
                    CommentImageUrl = x.reply.CommentImageUrl, // Direct from DB
                    UpvoteCount = x.reply.UpvoteCount,
                    CreatedBy = x.reply.CreatedBy,
                    CreatedAt = x.reply.CreatedAt,
                    CreatedByUserName = x.user.UserName,
                    CreatedByEmail = x.user.Email,
                    CreatedByProfilePic = x.pic != null ? x.pic.ImageUrl : null
                })
                .ToListAsync();
        }

        public async Task<StoreThreadReplyDTOReadOnly?> GetByIdAsync(int id)
        {
            return await _context.Store_ThreadReplies
                .Where(r => r.Id == id)
                .Join(
                    _context.Users,
                    reply => reply.CreatedBy,
                    user => user.Id,
                    (reply, user) => new { reply, user }
                )
                .GroupJoin(
                    _context.System_ProfilePictures,
                    ru => ru.user.Id,
                    pic => pic.UserId,
                    (ru, pics) => new { ru.reply, ru.user, pic = pics.FirstOrDefault() }
                )
                .Select(x => new StoreThreadReplyDTOReadOnly
                {
                    Id = x.reply.Id,
                    ThreadID = x.reply.ThreadID,
                    ThreadComment = x.reply.ThreadComment,
                    CommentImageUrl = x.reply.CommentImageUrl,
                    UpvoteCount = x.reply.UpvoteCount,
                    CreatedBy = x.reply.CreatedBy,
                    CreatedAt = x.reply.CreatedAt,
                    CreatedByUserName = x.user.UserName,
                    CreatedByEmail = x.user.Email,
                    CreatedByProfilePic = x.pic != null ? x.pic.ImageUrl : null
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<StoreThreadReplyDTOReadOnly>> GetAllByUserIdAsync(string userId)
        {
            return await _context.Store_ThreadReplies
                .Where(r => r.CreatedBy == userId)
                .Join(
                    _context.Users,
                    reply => reply.CreatedBy,
                    user => user.Id,
                    (reply, user) => new { reply, user }
                )
                .GroupJoin(
                    _context.System_ProfilePictures,
                    ru => ru.user.Id,
                    pic => pic.UserId,
                    (ru, pics) => new { ru.reply, ru.user, pic = pics.FirstOrDefault() }
                )
                .Select(x => new StoreThreadReplyDTOReadOnly
                {
                    Id = x.reply.Id,
                    ThreadID = x.reply.ThreadID,
                    ThreadComment = x.reply.ThreadComment,
                    CommentImageUrl = x.reply.CommentImageUrl,
                    UpvoteCount = x.reply.UpvoteCount,
                    CreatedBy = x.reply.CreatedBy,
                    CreatedAt = x.reply.CreatedAt,
                    CreatedByUserName = x.user.UserName,
                    CreatedByEmail = x.user.Email,
                    CreatedByProfilePic = x.pic != null ? x.pic.ImageUrl : null
                })
                .ToListAsync();
        }


        public async Task<StoreThreadReplyDTO> CreateAsync(StoreThreadReplyDTO dto)
        {
            var newReply = new StoreThreadReply
            {
                ThreadID = dto.ThreadID,
                ThreadComment = dto.ThreadComment,
                CommentImageUrl = dto.CommentImageUrl,
                CreatedBy = dto.CreatedBy,
                UpvoteCount = 0
            };

            _context.Store_ThreadReplies.Add(newReply);
            await _context.SaveChangesAsync();

            dto.Id = newReply.Id;
            dto.CreatedAt = newReply.CreatedAt;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reply = await _context.Store_ThreadReplies.FindAsync(id);
            if (reply == null) return false;

            _context.Store_ThreadReplies.Remove(reply);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<StoreThreadReplyUpvoteHistoryDTOReadOnly>> GetAllReplyUpvotesAsync()
        {
            return await _context.Store_ThreadReplyUpvoteHistories
                .Join(
                    _context.Users,
                    upvote => upvote.UserId,
                    user => user.Id,
                    (upvote, user) => new { upvote, user }
                )
                .Join(
                    _context.Store_ThreadReplies,
                    combined => combined.upvote.ThreadCommentId,
                    reply => reply.Id,
                    (combined, reply) => new StoreThreadReplyUpvoteHistoryDTOReadOnly
                    {
                        Id = combined.upvote.Id,
                        UserId = combined.upvote.UserId,
                        UserName = combined.user.UserName,
                        Email = combined.user.Email,
                        ThreadCommentId = combined.upvote.ThreadCommentId,
                        ThreadComment = reply.ThreadComment,
                        commentUrl = reply.CommentImageUrl,
                        CreatedAt = combined.upvote.CreatedAt
                    }
                )
                .ToListAsync();
        }

        public async Task<StoreThreadReplyUpvoteHistoryDTOReadOnly?> GetReplyUpvoteByIdAsync(int id)
        {
            return await _context.Store_ThreadReplyUpvoteHistories
                .Where(upvote => upvote.Id == id)
                .Join(
                    _context.Users,
                    upvote => upvote.UserId,
                    user => user.Id,
                    (upvote, user) => new { upvote, user }
                )
                .Join(
                    _context.Store_ThreadReplies,
                    combined => combined.upvote.ThreadCommentId,
                    reply => reply.Id,
                    (combined, reply) => new StoreThreadReplyUpvoteHistoryDTOReadOnly
                    {
                        Id = combined.upvote.Id,
                        UserId = combined.upvote.UserId,
                        UserName = combined.user.UserName,
                        Email = combined.user.Email,
                        ThreadCommentId = combined.upvote.ThreadCommentId,
                        ThreadComment = reply.ThreadComment,
                        commentUrl = reply.CommentImageUrl,
                        CreatedAt = combined.upvote.CreatedAt
                    }
                )
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<StoreThreadReplyUpvoteHistoryDTOReadOnly>> SearchReplyUpvotesByUserAsync(string searchTerm)
        {
            return await _context.Store_ThreadReplyUpvoteHistories
                .Join(
                    _context.Users,
                    upvote => upvote.UserId,
                    user => user.Id,
                    (upvote, user) => new { upvote, user }
                )
                .Join(
                    _context.Store_ThreadReplies,
                    combined => combined.upvote.ThreadCommentId,
                    reply => reply.Id,
                    (combined, reply) => new { combined.upvote, combined.user, reply }
                )
                .Where(result =>
                    result.user.Id.Contains(searchTerm) ||
                    result.user.UserName.Contains(searchTerm) ||
                    result.user.Email.Contains(searchTerm) ||
                    result.user.PhoneNumber.Contains(searchTerm)
                )
                .Select(result => new StoreThreadReplyUpvoteHistoryDTOReadOnly
                {
                    Id = result.upvote.Id,
                    UserId = result.upvote.UserId,
                    UserName = result.user.UserName,
                    Email = result.user.Email,
                    ThreadCommentId = result.upvote.ThreadCommentId,
                    ThreadComment = result.reply.ThreadComment,
                    commentUrl = result.reply.CommentImageUrl,
                    CreatedAt = result.upvote.CreatedAt
                })
                .ToListAsync();
        }



        public async Task<StoreThreadReplyUpvoteHistoryDTO> CreateReplyUpvoteAsync(StoreThreadReplyUpvoteHistoryDTO dto)
        {
            var entity = new StoreThreadReplyUpvoteHistory
            {
                UserId = dto.UserId,
                ThreadCommentId = dto.ThreadCommentId,
                CreatedAt = dto.CreatedAt
            };

            _context.Store_ThreadReplyUpvoteHistories.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return dto;
        }

        public async Task<bool> DeleteReplyUpvoteAsync(int id)
        {
            var record = await _context.Store_ThreadReplyUpvoteHistories.FindAsync(id);
            if (record == null) return false;

            _context.Store_ThreadReplyUpvoteHistories.Remove(record);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ToggleReplyUpvoteAsync(string userId, int replyId)
        {
            var reply = await _context.Store_ThreadReplies.FindAsync(replyId);
            if (reply == null) return false;

            var existingUpvote = await _context.Store_ThreadReplyUpvoteHistories
                .FirstOrDefaultAsync(u => u.UserId == userId && u.ThreadCommentId == replyId);

            if (existingUpvote != null)
            {

                _context.Store_ThreadReplyUpvoteHistories.Remove(existingUpvote);
                reply.UpvoteCount = Math.Max(0, reply.UpvoteCount - 1);
                await _context.SaveChangesAsync();
                return false;
            }
            else
            {

                var newUpvote = new StoreThreadReplyUpvoteHistory
                {
                    UserId = userId,
                    ThreadCommentId = replyId,
                    CreatedAt = DateTime.UtcNow
                };
                _context.Store_ThreadReplyUpvoteHistories.Add(newUpvote);
                reply.UpvoteCount += 1;
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
