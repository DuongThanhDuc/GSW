using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IGamesBannerRepository
    {
        void CreateBanner(GamesBannerDTO dto);
        void UpdateBanner(int id, GamesBannerDTO dto);
        void DeleteBanner(int id);
        GamesBannerDTO GetBannerById(int id);
        IEnumerable<GamesBannerDTO> GetAllBanners();
    }
}
