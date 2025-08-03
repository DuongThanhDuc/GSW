using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessModel.Model;

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
                .OrderByDescending(t => t.CreatedAt)
                .Select(t => new StoreThreadDTO
                {
                    Id = t.Id,
                    ThreadTitle = t.ThreadTitle,
                    ThreadDescription = t.ThreadDescription,
                    ThreadImageUrl = t.ThreadImageUrl,
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
                ThreadImageUrl = thread.ThreadImageUrl,
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
                ThreadImageUrl = dto.ThreadImageUrl,
                CreatedBy = dto.CreatedBy,
                CreatedAt = DateTime.UtcNow,
                UpvoteCount = 0
            };

            _context.Store_Threads.Add(newThread);
            await _context.SaveChangesAsync();

            return new StoreThreadDTO
            {
                Id = newThread.Id,
                ThreadTitle = newThread.ThreadTitle,
                ThreadDescription = newThread.ThreadDescription,
                ThreadImageUrl = newThread.ThreadImageUrl,
                CreatedBy = newThread.CreatedBy,
                UpvoteCount = newThread.UpvoteCount,
                CreatedAt = newThread.CreatedAt
            };
        }

        public async Task<bool> UpdateAsync(StoreThreadDTO dto)
        {
            var thread = await _context.Store_Threads.FindAsync(dto.Id);
            if (thread == null) return false;

            thread.ThreadTitle = dto.ThreadTitle;
            thread.ThreadDescription = dto.ThreadDescription;
            thread.ThreadImageUrl = dto.ThreadImageUrl;
            thread.UpvoteCount = dto.UpvoteCount;
            thread.CreatedBy = dto.CreatedBy;

            _context.Store_Threads.Update(thread);
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
    }
}
