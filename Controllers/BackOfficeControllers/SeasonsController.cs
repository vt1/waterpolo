using System.Collections.Generic;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Umbraco.Core.Persistence;
using Umbraco.Core;
using Umbraco.Web.WebApi;
using ywp.Models;
using System;

namespace ywp.Controllers
{
    //routes available after authorization to backoffice only
    public class SeasonsController : UmbracoAuthorizedApiController
    {
        // GET: Seasons
        [HttpGet]
        //http://<host>/umbraco/backoffice/api/seasons/getall/
        public JsonResult<List<Season>> GetAll()
        {
            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
            var result = db.Fetch<Season>(new Sql()
                                              .Select("*")
                                              .From("Seasons"));
            return Json(result);
        }

        //http://<host>/umbraco/backoffice/api/seasons/getbyid/1
        [HttpGet]
        public JsonResult<Season> GetById(int id = 1)
        {

            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
            //var result = db.SingleOrDefault<Season>(string.Format("SELECT * FROM Seasons WHERE Season_Id = {0}", id));
            //or
            var result = db.SingleOrDefault<Season>(new Sql()
                                                        .Select("*")
                                                        .From("Seasons")
                                                        .Where(string.Format("Season_Id = {0}", id)));
            return Json(result);
        }

        [HttpPost]
        public System.Web.Http.IHttpActionResult AddSeason(Season season)
        {   
            if(ModelState.IsValid)
            {
                //get unfilled model fields
            }
            
            if(season.Season_Title.IsNullOrWhiteSpace() || season.Season_Location.IsNullOrWhiteSpace() ||
                season.Season_Start_Date == DateTime.MinValue || season.Season_End_Date == DateTime.MinValue)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, "Null fields");
            }

            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;            
            var seasonToAdd = new Season
            {
                Season_Title = season.Season_Title,
                Season_Location = season.Season_Location,
                Season_Start_Date = season.Season_Start_Date,
                Season_End_Date = season.Season_End_Date
            };

            try
            {
                db.Insert(seasonToAdd);
            }
            catch(System.Exception exception)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, exception);
            }

            return Ok(seasonToAdd);
        }

        [HttpDelete]
        [Route("/umbraco/backoffice/api/seasons/deleteseason/{id}")]
        public System.Web.Http.IHttpActionResult DeleteSeason(int id)
        {
            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;            
            try
            {                
                db.Delete<Season>(id);
            }
            catch(System.Exception exception)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, exception);
            }

            return Ok();
        }

        [HttpPost]
        public System.Web.Http.IHttpActionResult UpdateSeason(Season season)
        {
            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
            try
            {
                db.Update(new Season
                {
                    Season_Id = season.Season_Id,
                    Season_Title = season.Season_Title,
                    Season_Location = season.Season_Location,
                    Season_Start_Date = season.Season_Start_Date,
                    Season_End_Date = season.Season_End_Date
                });
            }
            catch(System.Exception exception)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, exception);
            }
            
            return Ok();
        }
    }
}