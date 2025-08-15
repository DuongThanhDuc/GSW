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

        public async Task<IEnumerable<StoreThreadDTOReadOnly>> GetAllAsync()
        {
            return await _context.Store_Threads
                .Join(
                    _context.Users,
                    thread => thread.CreatedBy,
                    user => user.Id,
                    (thread, user) => new { thread, user }
                )
                .GroupJoin(
                    _context.System_ProfilePictures,
                    tu => tu.user.Id,
                    pic => pic.UserId,
                    (tu, pics) => new { tu.thread, tu.user, pic = pics.FirstOrDefault() }
                )
                .Select(x => new StoreThreadDTOReadOnly
                {
                    Id = x.thread.Id,
                    ThreadTitle = x.thread.ThreadTitle,
                    ThreadDescription = x.thread.ThreadDescription,
                    ThreadImageUrl = x.thread.ThreadImageUrl,
                    UpvoteCount = x.thread.UpvoteCount,
                    CreatedBy = x.thread.CreatedBy,
                    CreatedAt = x.thread.CreatedAt,
                    CreatedByUserName = x.user.UserName,
                    CreatedByEmail = x.user.Email,
                    CreatedByProfilePic = x.pic != null ? x.pic.ImageUrl : null
                })
                .ToListAsync();
        }

        public async Task<StoreThreadDTOReadOnly?> GetByIdAsync(int id)
        {
            return await _context.Store_Threads
                .Where(t => t.Id == id)
                .Join(
                    _context.Users,
                    thread => thread.CreatedBy,
                    user => user.Id,
                    (thread, user) => new { thread, user }
                )
                .GroupJoin(
                    _context.System_ProfilePictures,
                    tu => tu.user.Id,
                    pic => pic.UserId,
                    (tu, pics) => new { tu.thread, tu.user, pic = pics.FirstOrDefault() }
                )
                .Select(x => new StoreThreadDTOReadOnly
                {
                    Id = x.thread.Id,
                    ThreadTitle = x.thread.ThreadTitle,
                    ThreadDescription = x.thread.ThreadDescription,
                    ThreadImageUrl = x.thread.ThreadImageUrl,
                    UpvoteCount = x.thread.UpvoteCount,
                    CreatedBy = x.thread.CreatedBy,
                    CreatedAt = x.thread.CreatedAt,
                    CreatedByUserName = x.user.UserName,
                    CreatedByEmail = x.user.Email,
                    CreatedByProfilePic = x.pic != null ? x.pic.ImageUrl : null
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<StoreThreadDTOReadOnly>> GetAllByUserIdAsync(string userId)
        {
            return await _context.Store_Threads
                .Where(t => t.CreatedBy == userId)
                .Join(
                    _context.Users,
                    thread => thread.CreatedBy,
                    user => user.Id,
                    (thread, user) => new { thread, user }
                )
                .GroupJoin(
                    _context.System_ProfilePictures,
                    tu => tu.user.Id,
                    pic => pic.UserId,
                    (tu, pics) => new { tu.thread, tu.user, pic = pics.FirstOrDefault() }
                )
                .Select(x => new StoreThreadDTOReadOnly
                {
                    Id = x.thread.Id,
                    ThreadTitle = x.thread.ThreadTitle,
                    ThreadDescription = x.thread.ThreadDescription,
                    ThreadImageUrl = x.thread.ThreadImageUrl,
                    UpvoteCount = x.thread.UpvoteCount,
                    CreatedBy = x.thread.CreatedBy,
                    CreatedAt = x.thread.CreatedAt,
                    CreatedByUserName = x.user.UserName,
                    CreatedByEmail = x.user.Email,
                    CreatedByProfilePic = x.pic != null ? x.pic.ImageUrl : null
                })
                .ToListAsync();
        }



        public async Task<StoreThreadDTO> CreateAsync(StoreThreadDTO dto)
        {
            var newThread = new StoreThread
            {
                ThreadTitle = dto.ThreadTitle,
                ThreadDescription = dto.ThreadDescription,
                ThreadImageUrl = dto.ThreadImageUrl,
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

        public async Task<IEnumerable<StoreThreadUpvoteHistoryDTOReadOnly>> GetAllUpvoteHistoriesAsync()
        {
            return await _context.Store_ThreadUpvoteHistories
                .Join(
                    _context.Users,
                    history => history.UserID,
                    user => user.Id,
                    (history, user) => new StoreThreadUpvoteHistoryDTOReadOnly
                    {
                        Id = history.Id,
                        UserID = history.UserID,
                        Username = user.UserName,
                        Email = user.Email,
                        Phone = user.PhoneNumber,
                        ThreadID = history.ThreadID,
                        CreatedAt = history.CreatedAt
                    }
                ).ToListAsync();
        }

        public async Task<StoreThreadUpvoteHistoryDTOReadOnly?> GetUpvoteHistoryByIdAsync(int id)
        {
            var result = await _context.Store_ThreadUpvoteHistories
                .Where(h => h.Id == id)
                .Join(
                    _context.Users,
                    history => history.UserID,
                    user => user.Id,
                    (history, user) => new StoreThreadUpvoteHistoryDTOReadOnly
                    {
                        Id = history.Id,
                        UserID = history.UserID,
                        Username = user.UserName,
                        Email = user.Email,
                        Phone = user.PhoneNumber,
                        ThreadID = history.ThreadID,
                        CreatedAt = history.CreatedAt
                    }
                ).FirstOrDefaultAsync();

            return result;
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

        public async Task<IEnumerable<StoreThreadUpvoteHistoryDTOReadOnly>> GetAllUpvoteHistoriesByUserSearchAsync(string? query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<StoreThreadUpvoteHistoryDTOReadOnly>();

            query = query.ToLower();

            var results = await _context.Store_ThreadUpvoteHistories
                .Join(
                    _context.Users,
                    upvote => upvote.UserID,
                    user => user.Id,
                    (upvote, user) => new { upvote, user }
                )
                .Where(x =>
                    (x.user.Id != null && x.user.Id.ToLower().Contains(query)) ||
                    (x.user.UserName != null && x.user.UserName.ToLower().Contains(query)) ||
                    (x.user.Email != null && x.user.Email.ToLower().Contains(query)) ||
                    (x.user.PhoneNumber != null && x.user.PhoneNumber.ToLower().Contains(query))
                )
                .Join(
                    _context.Store_Threads,
                    combined => combined.upvote.ThreadID,
                    thread => thread.Id,
                    (combined, thread) => new StoreThreadUpvoteHistoryDTOReadOnly
                    {
                        Id = combined.upvote.Id,
                        UserID = combined.user.Id,
                        Username = combined.user.UserName,
                        Email = combined.user.Email,
                        Phone = combined.user.PhoneNumber,
                        ThreadID = combined.upvote.ThreadID,
                        CreatedAt = combined.upvote.CreatedAt
                    }
                )
                .ToListAsync();

            return results;
        }
    }
}
