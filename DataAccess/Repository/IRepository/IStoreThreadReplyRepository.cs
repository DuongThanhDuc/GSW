using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IStoreThreadReplyRepository
    {
        // Thread reply methods
        Task<IEnumerable<StoreThreadReplyDTOReadOnly>> GetAllAsync();
        Task<StoreThreadReplyDTOReadOnly?> GetByIdAsync(int id);
        Task<IEnumerable<StoreThreadReplyDTOReadOnly>> GetAllByUserIdAsync(string userId);
        Task<StoreThreadReplyDTO> CreateAsync(StoreThreadReplyDTO dto);
        Task<bool> DeleteAsync(int id);

        // Upvote history methods
        Task<IEnumerable<StoreThreadReplyUpvoteHistoryDTOReadOnly>> GetAllReplyUpvotesAsync();
        Task<StoreThreadReplyUpvoteHistoryDTOReadOnly?> GetReplyUpvoteByIdAsync(int id);
        Task<IEnumerable<StoreThreadReplyUpvoteHistoryDTOReadOnly>> SearchReplyUpvotesByUserAsync(string searchTerm);
        Task<StoreThreadReplyUpvoteHistoryDTO> CreateReplyUpvoteAsync(StoreThreadReplyUpvoteHistoryDTO dto);
        Task<bool> DeleteReplyUpvoteAsync(int id);
        Task<bool> ToggleReplyUpvoteAsync(string userId, int replyId);
    }
}
