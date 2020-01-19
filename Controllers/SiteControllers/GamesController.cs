using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using ywp.DAL;
using ywp.Models.SiteViewModels;

namespace ywp.Controllers.SiteControllers
{
    public class GamesController : Umbraco.Web.Mvc.RenderMvcController
    {
        public ActionResult Games(RenderModel model, int id)
        {
            DbFactory db = new DbFactory();
            GameViewModel gameViewModel = new GameViewModel(model.Content)
            {
                Games = db.GetAllGamesBySeasonId(id),
                Season = db.GetSeasonById(id)
            };
            return base.Index(gameViewModel);
        }

        public ActionResult GameInfo(RenderModel model, int id)
        {
            DbFactory db = new DbFactory();
            GameViewModel gameViewModel = new GameViewModel(model.Content)
            {
                GameInfo = db.GetGameById(id)
            };
            return CurrentTemplate(gameViewModel);
        }
    }
}