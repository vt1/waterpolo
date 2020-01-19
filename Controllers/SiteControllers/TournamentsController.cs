using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Web.Models;
using ywp.Models.SiteViewModels;
using ywp.DAL;

namespace ywp.Controllers.SiteControllers
{
    // Seasons
    public class TournamentsController : RenderMvcController
    {
        public ActionResult Tournaments(RenderModel model)
        {
            DbFactory db = new DbFactory();
            SeasonViewModel seasonViewModel = new SeasonViewModel(model.Content)
            {
                Seasons = db.GetAllSeasons()
            };

            return CurrentTemplate(seasonViewModel);
        }       
    }
}