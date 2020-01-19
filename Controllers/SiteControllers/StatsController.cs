using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using ywp.BLL;
using ywp.DAL;
using ywp.Models.SiteModels;
using ywp.Models.SiteViewModels;

namespace ywp.Controllers.SiteControllers
{
    public class StatsController : RenderMvcController
    {
        public ActionResult Stats(RenderModel model)
        {
            StatViewModel statViewModel = new StatViewModel(model.Content);
            return base.Index(statViewModel);
        }

        public ActionResult GameLog(RenderModel model, int id)
        {
            DbFactory db = new DbFactory();
            StatsBLL statsBll = new StatsBLL();
            var GameLog = db.GetStatGameLogByGameId(id);            

            StatViewModel statViewModel = new StatViewModel(model.Content)
            {
                Game = db.GetGameById(id),
                GameLogPeriod = GameLog.Count == 0 ? null : statsBll.GameLogIntoGameLogPeriod(GameLog)
            };
            return CurrentTemplate(statViewModel);
        }

        public ActionResult Totals(RenderModel model, int id)
        {
            DbFactory db = new DbFactory();
            StatsBLL statsBll = new StatsBLL();
            
            StatViewModel statViewModel = new StatViewModel(model.Content)
            {
                Game = db.GetGameById(id),
                RosterStats = statsBll.ProcessTotalStats(id),                
                GameTotalsScore = statsBll.ProcessGameTotalsScore(id)
            };
            statViewModel.StatTypes = statViewModel.RosterStats.Count == 0 ? null : db.GetAllStatTypes();
            
            return CurrentTemplate(statViewModel);
        }
    }
}