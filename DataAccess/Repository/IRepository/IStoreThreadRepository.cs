using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IStoreThreadRepository
    {
        Task<IEnumerable<StoreThreadDTOReadOnly>> GetAllAsync();
        Task<StoreThreadDTOReadOnly?> GetByIdAsync(int id);
        Task<IEnumerable<StoreThreadDTOReadOnly>> GetAllByUserIdAsync(string userId);
        Task<StoreThreadDTO> CreateAsync(StoreThreadDTO dto);
        Task<bool> UpdateAsync(StoreThreadDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<StoreThreadUpvoteHistoryDTOReadOnly>> GetAllUpvoteHistoriesAsync();
        Task<StoreThreadUpvoteHistoryDTOReadOnly?> GetUpvoteHistoryByIdAsync(int id);
        Task<IEnumerable<StoreThreadUpvoteHistoryDTOReadOnly>> GetAllUpvoteHistoriesByUserSearchAsync(string? query);
        Task<bool> ToggleUpvoteAsync(string userId, int threadId);

    }
}
