using BusinessModel.Model;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IGamesInfoRepository
    {
        Task<IEnumerable<GamesInfo>> GetAllAsyncOriginal();
        Task<GamesInfo?> GetByIdAsyncOriginal(int id);
        Task<IEnumerable<GamesInfoDTOReadOnly>> GetAllAsync();
        Task<GamesInfoDTOReadOnly?> GetByIdAsync(int id);
        Task<GamesInfoDTO> CreateAsync(GamesInfoDTO dto);
        Task<bool> UpdateAsync(GamesInfoDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> SetActiveStatusAsync(int id, bool isActive);
        Task<bool> UpdateStatusAsync(int id, string status);
        Task UpdateAsync(GamesInfo game);

        Task<IEnumerable<StoreWishlistDTO>> GetWishlistsByUserAsync(string userId);
        Task<bool> ToggleWishlistAsync(string userId, int gameId);
        Task<bool> IsGameInWishlistAsync(string userId, int gameId);


        // Discount-related
        //Task<GamesInfoDTO> GetByIdWithDiscountsAsync(int id);
        //Task<IEnumerable<GamesInfoDTO>> GetAllWithDiscountsAsync();
        //Task AddDiscountToGameAsync(int gameId, int discountId);
        //Task RemoveDiscountFromGameAsync(int gameId, int discountId);
    }
}
