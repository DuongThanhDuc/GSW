using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessModel.Model;

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
                .OrderBy(r => r.CreatedAt)
                .Select(r => new StoreThreadReplyDTO
                {
                    Id = r.Id,
                    ThreadID = r.ThreadID,
                    ThreadComment = r.ThreadComment,
                    CommentImageUrl = r.CommentImageUrl,
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
                CommentImageUrl = dto.CommentImageUrl,
                CreatedBy = dto.CreatedBy,
                CreatedAt = DateTime.UtcNow,
                UpvoteCount = 0
            };

            _context.Store_ThreadReplies.Add(newReply);
            await _context.SaveChangesAsync();

            return new StoreThreadReplyDTO
            {
                Id = newReply.Id,
                ThreadID = newReply.ThreadID,
                ThreadComment = newReply.ThreadComment,
                CommentImageUrl = newReply.CommentImageUrl,
                CreatedBy = newReply.CreatedBy,
                CreatedAt = newReply.CreatedAt,
                UpvoteCount = newReply.UpvoteCount
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var reply = await _context.Store_ThreadReplies.FindAsync(id);
            if (reply == null) return false;

            _context.Store_ThreadReplies.Remove(reply);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
