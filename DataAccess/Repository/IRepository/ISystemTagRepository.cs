using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface ISystemTagRepository
    {
        Task<IEnumerable<SystemTag>> GetAllAsync();
        Task<SystemTag?> GetByIdAsync(int id);
        Task<SystemTag?> GetByNameAsync(string name); 
        Task AddAsync(SystemTag tag);
        Task UpdateAsync(SystemTag tag);
        Task DeleteAsync(int id);
    }
}
