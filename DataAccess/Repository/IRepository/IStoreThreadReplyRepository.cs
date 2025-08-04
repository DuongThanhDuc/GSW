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
        Task<IEnumerable<StoreThreadReplyDTO>> GetAllByThreadIdAsync(int threadId);
        Task<StoreThreadReplyDTO> CreateAsync(StoreThreadReplyDTO dto);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<StoreThreadReplyUpvoteHistoryDTO>> GetAllReplyUpvotesAsync();
        Task<StoreThreadReplyUpvoteHistoryDTO?> GetReplyUpvoteByIdAsync(int id);
        Task<bool> ToggleReplyUpvoteAsync(string userId, int replyId);
    }
}
