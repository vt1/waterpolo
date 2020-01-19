using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using Umbraco.Web.Mvc;
using ywp.Models;
using ywp.Models.SiteModels;
using ywp.Models.SiteModels.Stats;

namespace ywp.DAL
{
    public class DbFactory
    {
        public UmbracoDatabase DbContext { get; }
        public DbFactory()
        {
            DbContext = ApplicationContext.Current.DatabaseContext.Database;
        }

        public List<Season> GetAllSeasons()
        {
            return DbContext.Fetch<Season>(new Sql()
                            .Select("*")
                            .From("Seasons"));
        }

        public List<Game> GetAllGamesBySeasonId(int Season_Id)
        {
            return DbContext.Fetch<Game>(";EXEC GetAllGamesBySeasonId @0", Season_Id);
        }

        public Game GetGameById(int Game_Id)
        {
            return DbContext.SingleOrDefault<Game>(";EXEC GetGameById @0", Game_Id);
        }

        public List<GameLog> GetStatGameLogByGameId(int Game_Id)
        {
            return DbContext.Fetch<GameLog>(";EXEC GetStatGameLogByGameId @0", Game_Id);
        }

        public Season GetSeasonById(int Season_Id)
        {
            return DbContext.SingleOrDefault<Season>(";EXEC GetSeasonById @0", Season_Id);
        }

        public List<TotalStats> GetTotalStatsByGameId(int Game_Id)
        {
            return DbContext.Fetch<TotalStats>(";EXEC GetTotalStatsByGameId @0", Game_Id);
        }

        public List<Roster> GetRostersByGameId(int Game_Id)
        {
            return DbContext.Fetch<Roster>(";EXEC GetRostersByGameId @0", Game_Id);
        }

        public List<StatType> GetAllStatTypes()
        {
            return DbContext.Fetch<StatType>(";EXEC GetAllStatTypes");
        }

        public List<GameTotalsScore> GetGameTotalsScoreByGameId(int Game_Id)
        {
            return DbContext.Fetch<GameTotalsScore>(";EXEC GetGameTotalsScoreByGameId @0", Game_Id);
        }

        public RosterInMember GetRosterInMemberByMemberId(int Node_Id)
        {
            return DbContext.SingleOrDefault<RosterInMember>(";EXEC GetRosterInMemberByMemberId @0", Node_Id);
        }

        public List<Season> GetSeasonsPlayedByPlayerId(int Player_Id)
        {
            return DbContext.Fetch<Season>(";EXEC GetSeasonsPlayedByPlayerId @0", Player_Id);
        }

        public List<Game> GetGamesByPlayerIdAndSeasonId(int Player_Id, int Season_Id)
        {
            return DbContext.Fetch<Game>(";EXEC GetGamesByPlayerIdAndSeasonId @0, @1", Player_Id, Season_Id);
        }
    }
}