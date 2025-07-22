using BusinessModel.Model;
using DataAccess.DTOs;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class SystemProfilePictureRepository : ISystemProfilePictureRepository
    {
        private readonly DBContext _context;

        public SystemProfilePictureRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<SystemProfilePictureDTO?> GetByUserIdAsync(string userId)
        {
            var entity = await _context.System_ProfilePictures
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserId == userId);

            return entity == null ? null : new SystemProfilePictureDTO
            {
                Id = entity.Id,
                UserId = entity.UserId,
                ImageUrl = entity.ImageUrl
            };
        }

        public async Task<IEnumerable<SystemProfilePictureDTO>> GetAllAsync()
        {
            return await _context.System_ProfilePictures
                .AsNoTracking()
                .Select(p => new SystemProfilePictureDTO
                {
                    Id = p.Id,
                    UserId = p.UserId,
                    ImageUrl = p.ImageUrl
                }).ToListAsync();
        }

        public async Task AddAsync(SystemProfilePictureDTO dto)
        {
            var entity = new SystemProfilePicture
            {
                UserId = dto.UserId,
                ImageUrl = dto.ImageUrl
            };

            _context.System_ProfilePictures.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SystemProfilePictureDTO dto)
        {
            var existing = await _context.System_ProfilePictures
                .FirstOrDefaultAsync(p => p.Id == dto.Id);

            if (existing == null) return;

            existing.ImageUrl = dto.ImageUrl;
            existing.UserId = dto.UserId;

            _context.System_ProfilePictures.Update(existing);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string userId)
        {
            var existing = await _context.System_ProfilePictures
                .FirstOrDefaultAsync(p => p.UserId == userId);

            if (existing == null) return;

            _context.System_ProfilePictures.Remove(existing);
            await _context.SaveChangesAsync();
        }

        public async Task CreateOrUpdateAsync(SystemProfilePictureDTO dto)
        {
            var existing = await _context.System_ProfilePictures
                .FirstOrDefaultAsync(p => p.UserId == dto.UserId);

            if (existing != null)
            {
                existing.ImageUrl = dto.ImageUrl;
                _context.System_ProfilePictures.Update(existing);
            }
            else
            {
                var entity = new SystemProfilePicture
                {
                    UserId = dto.UserId,
                    ImageUrl = dto.ImageUrl
                };
                await _context.System_ProfilePictures.AddAsync(entity);
            }

            await _context.SaveChangesAsync();
        }
    }
}
