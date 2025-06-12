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
    public class SystemCategoryRepository : ISystemCategoryRepository
    {
        private readonly DBContext _context;

        public SystemCategoryRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SystemCategory>> GetAllAsync()
        {
            return await _context.System_Categories.ToListAsync();
        }

        public async Task<SystemCategory> GetByIdAsync(int id)
        {
            return await _context.System_Categories.FindAsync(id);
        }

        public async Task<SystemCategory> GetByNameAsync(string name)
        {
            return await _context.System_Categories
                .FirstOrDefaultAsync(c => c.CategoryName.ToLower() == name.ToLower());
        }

        public async Task AddAsync(SystemCategory category)
        {
            _context.System_Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SystemCategory category)
        {
            _context.System_Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.System_Categories.FindAsync(id);
            if (category != null)
            {
                _context.System_Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
