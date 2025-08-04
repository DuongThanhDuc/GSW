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

        public async Task<IEnumerable<StoreThreadReplyDTO>> GetAllByThreadIdAsync(int threadId)
        {
            return await _context.Store_ThreadReplies
                .Where(r => r.ThreadID == threadId)
                .Select(r => new StoreThreadReplyDTO
                {
                    Id = r.Id,
                    ThreadID = r.ThreadID,
                    ThreadComment = r.ThreadComment,
                    UpvoteCount = r.UpvoteCount,
                    CreatedBy = r.CreatedBy,
                    CreatedAt = r.CreatedAt
                }).ToListAsync();
        }

        public async Task<StoreThreadReplyDTO> CreateAsync(StoreThreadReplyDTO dto)
        {
            var newReply = new StoreThreadReply
            {
                ThreadID = dto.ThreadID,
                ThreadComment = dto.ThreadComment,
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

        public async Task<IEnumerable<StoreThreadReplyUpvoteHistoryDTO>> GetAllReplyUpvotesAsync()
        {
            return await _context.Store_ThreadReplyUpvoteHistories
                .Select(u => new StoreThreadReplyUpvoteHistoryDTO
                {
                    Id = u.Id,
                    UserId = u.UserId,
                    ThreadCommentId = u.ThreadCommentId,
                    CreatedAt = u.CreatedAt
                }).ToListAsync();
        }

        public async Task<StoreThreadReplyUpvoteHistoryDTO?> GetReplyUpvoteByIdAsync(int id)
        {
            var record = await _context.Store_ThreadReplyUpvoteHistories.FindAsync(id);
            if (record == null) return null;

            return new StoreThreadReplyUpvoteHistoryDTO
            {
                Id = record.Id,
                UserId = record.UserId,
                ThreadCommentId = record.ThreadCommentId,
                CreatedAt = record.CreatedAt
            };
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
