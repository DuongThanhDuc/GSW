using BusinessModel.Model;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IGamesDiscountRepository
    {
        IEnumerable<GamesDiscount> GetAll();
        GamesDiscount Get(int id);
        GamesDiscount Create(GamesDiscount entity);
        GamesDiscount Update(int id, GamesDiscount entity);
        void Delete(int id);
        bool IsCodeExist(string code, int? ignoreId = null);

        GamesDiscount GetActiveDiscountByGameId(int gameId);
        void SetDiscountForGame(int gameId, int discountId); // Gán duy nhất 1 discount cho 1 game
        void RemoveDiscountFromGame(int gameId, int discountId);
    }
}
