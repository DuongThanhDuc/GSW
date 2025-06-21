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
    public class SystemMediaRepository : ISystemMediaRepository
    {
        private readonly DBContext _context;

        public SystemMediaRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<SystemMediaDTO> SaveMediaUrlAsync(string mediaUrl)
        {
            var media = new SystemMedia
            {
                MediaURL = mediaUrl
            };

            _context.System_Media.Add(media);
            await _context.SaveChangesAsync();

            return new SystemMediaDTO
            {
                Id = media.Id,
                MediaURL = media.MediaURL,
                CreatedAt = media.CreatedAt
            };
        }

        public async Task<SystemMedia> GetByIdAsync(int id)
        {
            return await _context.System_Media.FindAsync(id);
        }

        public async Task<IEnumerable<SystemMedia>> GetAllAsync()
        {
            return await _context.System_Media.ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var media = await _context.System_Media.FindAsync(id);
            if (media == null) return false;

            _context.System_Media.Remove(media);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
