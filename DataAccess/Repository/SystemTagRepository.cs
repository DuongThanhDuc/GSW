using BusinessModel.Model;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SystemTagRepository : ISystemTagRepository
    {
        private readonly DBContext _context;

        public SystemTagRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SystemTag>> GetAllAsync()
        {
            return await _context.System_Tags.ToListAsync();
        }

        public async Task<SystemTag?> GetByIdAsync(int id)
        {
            return await _context.System_Tags.FindAsync(id);
        }

        public async Task<SystemTag?> GetByNameAsync(string name)
        {
            return await _context.System_Tags.FirstOrDefaultAsync(t => t.TagName == name);
        }

        public async Task AddAsync(SystemTag tag)
        {
            await _context.System_Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SystemTag tag)
        {
            _context.System_Tags.Update(tag);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tag = await _context.System_Tags.FindAsync(id);
            if (tag != null)
            {
                _context.System_Tags.Remove(tag);
                await _context.SaveChangesAsync();
            }
        }
    }
}
