using BusinessModel.Model;
using DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IGamesMediaRepository
    {
        GamesInfoDTO GetGameInfoWithMedia(int gameId);
        void AddMediaToGame(int gameId, GamesMediaDTO mediaDto);
        void UpdateMediaInGame(int gameId, GamesMediaDTO mediaDto);
        void DeleteMediaFromGame(int gameId, int mediaId);
    }

}
