using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using Umbraco.Web.WebApi;
using ywp.Models;
using System.Web.Http.Results;

namespace ywp.Controllers
{
    public class GamesController : UmbracoAuthorizedApiController
    {
        [HttpGet]        
        public JsonResult<List<Game>> GetAll()
        {
            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
            var result = db.Fetch<Game>(new Sql()
                                              .Select("*")
                                              .From("Games"));
            return Json(result);
        }

        [HttpPost]
        public System.Web.Http.IHttpActionResult AddGame(Game game)
        {   
            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
            var gameToAdd = new Game
            {                
                Season_Id = game.Season_Id,
                Game_Date = game.Game_Date,
                Game_Location = game.Game_Location,
                Opposing_Team = game.Opposing_Team
            };

            try
            {
                db.Insert(gameToAdd);
            }
            catch (System.Exception exception)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, exception);
            }

            return Ok(gameToAdd);
        }

        [HttpDelete]
        [Route("/umbraco/backoffice/api/games/deletegame/{id}")]
        public System.Web.Http.IHttpActionResult DeleteGame(int id)
        {
            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
            try
            {
                db.Delete<Game>(id);
            }
            catch (System.Exception exception)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, exception);
            }

            return Ok();
        }

        [HttpPost]
        public System.Web.Http.IHttpActionResult UpdateGame(Game game)
        {
            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
            try
            {
                db.Update(new Game
                {
                    Game_Id = game.Game_Id,
                    Season_Id = game.Season_Id,
                    Game_Location = game.Game_Location,
                    Opposing_Team = game.Opposing_Team,
                    Game_Date = game.Game_Date
                });
            }
            catch (System.Exception exception)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, exception);
            }

            return Ok();
        }
    }
}