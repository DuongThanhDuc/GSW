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
    }
}
