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
    public class StoreThreadRepository : IStoreThreadRepository
    {
        private readonly DBContext _context;

        public StoreThreadRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StoreThreadDTO>> GetAllAsync()
        {
            return await _context.Store_Threads
                .Select(t => new StoreThreadDTO
                {
                    Id = t.Id,
                    ThreadTitle = t.ThreadTitle,
                    ThreadDescription = t.ThreadDescription,
                    UpvoteCount = t.UpvoteCount,
                    CreatedBy = t.CreatedBy,
                    CreatedAt = t.CreatedAt
                }).ToListAsync();
        }

        public async Task<StoreThreadDTO?> GetByIdAsync(int id)
        {
            var thread = await _context.Store_Threads.FindAsync(id);
            if (thread == null) return null;

            return new StoreThreadDTO
            {
                Id = thread.Id,
                ThreadTitle = thread.ThreadTitle,
                ThreadDescription = thread.ThreadDescription,
                UpvoteCount = thread.UpvoteCount,
                CreatedBy = thread.CreatedBy,
                CreatedAt = thread.CreatedAt
            };
        }

        public async Task<StoreThreadDTO> CreateAsync(StoreThreadDTO dto)
        {
            var newThread = new StoreThread
            {
                ThreadTitle = dto.ThreadTitle,
                ThreadDescription = dto.ThreadDescription,
                CreatedBy = dto.CreatedBy,
                UpvoteCount = 0
            };

            _context.Store_Threads.Add(newThread);
            await _context.SaveChangesAsync();

            dto.Id = newThread.Id;
            dto.CreatedAt = newThread.CreatedAt;
            return dto;
        }

        public async Task<bool> UpdateAsync(StoreThreadDTO dto)
        {
            var thread = await _context.Store_Threads.FindAsync(dto.Id);
            if (thread == null) return false;

            thread.ThreadTitle = dto.ThreadTitle;
            thread.ThreadDescription = dto.ThreadDescription;
            thread.UpvoteCount = dto.UpvoteCount;
            thread.CreatedBy = dto.CreatedBy;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var thread = await _context.Store_Threads.FindAsync(id);
            if (thread == null) return false;

            _context.Store_Threads.Remove(thread);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<StoreThreadUpvoteHistoryDTO>> GetAllUpvoteHistoriesAsync()
        {
            return await _context.Store_ThreadUpvoteHistories
                .Select(u => new StoreThreadUpvoteHistoryDTO
                {
                    Id = u.Id,
                    UserID = u.UserID,
                    ThreadID = u.ThreadID,
                    CreatedAt = u.CreatedAt
                }).ToListAsync();
        }

        public async Task<StoreThreadUpvoteHistoryDTO?> GetUpvoteHistoryByIdAsync(int id)
        {
            var history = await _context.Store_ThreadUpvoteHistories.FindAsync(id);
            if (history == null) return null;

            return new StoreThreadUpvoteHistoryDTO
            {
                Id = history.Id,
                UserID = history.UserID,
                ThreadID = history.ThreadID,
                CreatedAt = history.CreatedAt
            };
        }
        public async Task<bool> ToggleUpvoteAsync(string userId, int threadId)
        {
            var history = await _context.Store_ThreadUpvoteHistories
                .FirstOrDefaultAsync(h => h.UserID == userId && h.ThreadID == threadId);

            var thread = await _context.Store_Threads.FindAsync(threadId);
            if (thread == null) return false;

            if (history != null)
            {
                // User has already upvoted → remove it
                _context.Store_ThreadUpvoteHistories.Remove(history);
                thread.UpvoteCount = Math.Max(0, thread.UpvoteCount - 1);
                await _context.SaveChangesAsync();
                return false; // removed upvote
            }
            else
            {
                // New upvote
                var newHistory = new StoreThreadUpvoteHistory
                {
                    UserID = userId,
                    ThreadID = threadId,
                    CreatedAt = DateTime.UtcNow
                };
                _context.Store_ThreadUpvoteHistories.Add(newHistory);
                thread.UpvoteCount += 1;
                await _context.SaveChangesAsync();
                return true; // added upvote
            }
        }
    }
}
