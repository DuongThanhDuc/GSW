using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface ISystemCategoryRepository
    {
        Task<IEnumerable<SystemCategory>> GetAllAsync();
        Task<SystemCategory> GetByIdAsync(int id);
        Task<SystemCategory> GetByNameAsync(string name);
        Task AddAsync(SystemCategory category);
        Task UpdateAsync(SystemCategory category);
        Task DeleteAsync(int id);
    }
}
