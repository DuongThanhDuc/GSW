using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IGameStatisticRepository
    {
        Task<List<TopSellingGameDTO>> GetTopSellingGamesAsync(DateTime from, DateTime to, int topN);
        Task<TopSellingGamePagingDTO> GetTopSellingGamesAsync(TopSellingGameRequestDTO req);
    }
}
