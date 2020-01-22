using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ywp.DAL;
using ywp.Models.SiteModels;
using ywp.Models.SiteModels.Stats;
using ywp.CustomUtilities;

namespace ywp.BLL
{
    public class StatsBLL
    {
	private DbFactory db = new DbFactory();

        /*
         * function expects that input parameter(list) is order by -_Period_- 
        */
        public List<GameLogPeriod> GameLogIntoGameLogPeriod(List<GameLog> gameLogList)
        {
            List<GameLogPeriod> gameLogPeriodList = new List<GameLogPeriod>();
            int tmpPeriod = gameLogList[0].Period;
            while(gameLogList.Count != 0)
            {
                GameLogPeriod gameLogPeriod = new GameLogPeriod();
                gameLogPeriod.Period = tmpPeriod;

                /*
                 * in foreach expression i use ToList() because it creates a copy
                 * and it allows to delete list elements inside foreach on the run
                 * and go through next elem without leaving foreach scope
                */
                foreach (var gl in gameLogList.ToList())
                {
                    if(gameLogPeriod.Period == gl.Period)
                    {                        
                        gameLogPeriod.GameLog.Add(gl);
                        gameLogList.Remove(gl);
                    }
                    else
                    {
                        gameLogPeriodList.Add(gameLogPeriod);
                        tmpPeriod = gl.Period;
                        break;
                    }
                }

                if (gameLogList.Count == 0)
                    gameLogPeriodList.Add(gameLogPeriod);
            }
            return gameLogPeriodList;
        }

        /*
         * function expects that TotalStats datas have already ordered by Player_Id, Stat_Type_Id
        */
        public List<RosterStats> ProcessTotalStats(int Game_Id)
        {
            // get all stat types (13)
            var statTypes = db.GetAllStatTypes();

            // get full stats of current game, contains all existing stats and players belonging to this one
            var totalStats = db.GetTotalStatsByGameId(Game_Id);            

            var rosterStatTypeList = new List<RosterStatType>();
            var rosterStatsList = new List<RosterStats>();

            if (totalStats.Count == 0)
                return rosterStatsList;

            int currentPlayerId = totalStats[0].Player_Id;

            /*
             * separation by players (input: totalStats list)
             * constructing new instances RosterStatType/RosterStats and adding it to RosterStats list 
             * used for instead foreach in order to operate with index
            */
            for (int i = 0; i < totalStats.Count; i++)
            {
                var rosterStatType = new RosterStatType();
                var rosterStats = new RosterStats();

                if (currentPlayerId != totalStats[i].Player_Id)
                {                    
                    rosterStats.Player_Name = totalStats[--i].Player_Name;
                    i++;

                    rosterStats.RosterStatType = rosterStatTypeList.ToList();
                    rosterStatsList.Add(rosterStats);
                    rosterStatTypeList.Clear();

                    currentPlayerId = totalStats[i].Player_Id;
                }

                if (currentPlayerId == totalStats[i].Player_Id)
                {
                    rosterStatType.Stat_Type_Id = totalStats[i].Stat_Type_Id;
                    rosterStatType.Score = totalStats[i].Score;

                    rosterStatTypeList.Add(rosterStatType);
                }
                
                if(totalStats.Count - 1 == i)
                {
                    rosterStats.Player_Name = totalStats[i].Player_Name;
                    rosterStats.RosterStatType = rosterStatTypeList.ToList();

                    rosterStatsList.Add(rosterStats);
                    rosterStatTypeList.Clear();
                }
            }                        
            
            // stats type id always begins from 1
            int tmpStatTypeId = 1;
            Utils utils = new Utils();

            /*
             * there are 13 stat types
             * e.g. player in game only did 1 block and 1 assist = (2 stat types)
             * e.g. to show nulls for other stat types player in table  
             * search for stat types that player didnt do in game and set (stat_type.Score = 0)
            */
            for(int j = 0; j < rosterStatsList.Count; j++)
            {
                var rosterStat = rosterStatsList[j];
                for (int i = 0; i < statTypes.Count; i++)
                {
                    //if (!utils.isStatTypeIdInRange(rosterStat.RosterStatType, tmpStatTypeId))
                    if(!rosterStat.RosterStatType.Exists(item => (item.Stat_Type_Id == tmpStatTypeId)))
                    {
                        var model = new RosterStatType()
                        {
                            Score = 0,
                            Stat_Type_Id = tmpStatTypeId
                        };
                        rosterStatsList[j].RosterStatType.Add(model);
                    }
                    tmpStatTypeId++;
                }
                tmpStatTypeId = 1;
            }

            // sort RosterStatsList by RosterStatType.Stat_Type_Id 
            for (int i = 0; i < rosterStatsList.Count; i++)
            {
                rosterStatsList[i].RosterStatType = rosterStatsList[i].RosterStatType.OrderBy(o => o.Stat_Type_Id).ToList();
            }

            return rosterStatsList;
        }
        
        public List<GameTotalsScore> ProcessGameTotalsScore(int Game_Id)
        {
            Utils utils = new Utils();
            var statTypes = db.GetAllStatTypes();
            var gameTotalsScoreList = db.GetGameTotalsScoreByGameId(Game_Id);

            int tmpStatTypeId = 1;            
            for (int i = 0; i < statTypes.Count; i++)
            {
                //if (!utils.isStatTypeIdInRange(gameTotalsScoreList, tmpStatTypeId))
                if(!gameTotalsScoreList.Exists(item => (item.Stat_Type_Id == tmpStatTypeId)))
                {
                    var model = new GameTotalsScore()
                    {
                        Total_Score = 0,
                        Stat_Type_Id = tmpStatTypeId
                    };
                    gameTotalsScoreList.Add(model);
                }
                tmpStatTypeId++;
            }
            tmpStatTypeId = 1;

            List<GameTotalsScore> sorted = gameTotalsScoreList.OrderBy(o => o.Stat_Type_Id).ToList();
            return sorted;
        }
    }
}
 
 