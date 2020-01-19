using System.Collections.Generic;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Umbraco.Core.Persistence;
using Umbraco.Core;
using Umbraco.Web.WebApi;
using ywp.Models;
using System;
using System.Net.Http;
using System.Web;
using System.IO;
using CsvHelper;
using System.Threading.Tasks;
using System.Linq;
using System.Web.Http;
using System.Net;
using System.Data.SqlClient;

namespace ywp.Controllers
{
    public class StatsController : UmbracoAuthorizedApiController
    {
        [System.Web.Mvc.HttpPost]
        public async Task<HttpResponseMessage> Upload()
        {            
            if (!this.Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
            var provider = new MultipartFormDataStreamProvider(Path.GetTempPath());
            await Request.Content.ReadAsMultipartAsync(provider);

            var file = provider.FileData.Count > 0 ? provider.FileData.First() : null;
            // check if any file is uploaded
            if(file == null)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No file uploaded");
            }

            string fileName = file.Headers.ContentDisposition.FileName.Trim('"');
            string fileExtension = fileName.Substring(fileName.LastIndexOf('.') + 1);
            // check if the file of the required type
            if(fileExtension != "csv")
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Required format *.csv");
            }

            string gameId = provider.FormData.GetValues("gameId").First();
            var game = new Game();
            // check if game is selected
            if(gameId != "undefined")
            {
                // get game instance for uploaded file
                game = db.SingleOrDefault<Game>(new Sql()
                            .Select("*")
                            .From("Games")
                            .Where(string.Format("Game_Id = {0}", Int32.Parse(gameId))));
            }
            else
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "No game selected");
            }
            
            // get all stat types to parse file
            var statTypes = db.Fetch<StatType>(new Sql()
                                              .Select("*")
                                              .From("StatTypes"));
            
                        
            string[] csvFileContent = File.ReadAllLines(file.LocalFileName);
            foreach(string line in csvFileContent.Skip(1))
            {               
                if(!line.IsNullOrWhiteSpace())
                {
                    string[] words = line.Split(',');   // contains period, time, descr, playerid
                    int statTypeId = 0;
                    foreach(var statType in statTypes)
                    {
                        // parse *description* from CSV to match it with StatType
                        if(words[2].Contains(statType.Stat_Type_Keyphrase))
                        {
                            statTypeId = statType.Stat_Type_Id;
                            break;
                        }
                    }

                    var stat = new Stat
                    {
                        Game_Id = game.Game_Id,
                        Period = Int32.Parse(words[0]),
                        Stat_Time = new DateTime(game.Game_Date.Year, game.Game_Date.Month, game.Game_Date.Day,
                                                    Int32.Parse(words[1].Substring(0, words[1].LastIndexOf(':'))),
                                                    Int32.Parse(words[1].Substring(words[1].LastIndexOf(':') + 1)), 0),
                        Stat_Type_Id = statTypeId,
                        Player_Id = Int32.Parse(words[3])
                    };                    
                    db.Insert(stat);
                }                
            }
            
            return new HttpResponseMessage(HttpStatusCode.OK);            
        }

        [System.Web.Mvc.HttpDelete]
        [System.Web.Mvc.Route("/umbraco/backoffice/api/stats/deleteallstatsbygameid/{id}")]
        public System.Web.Http.IHttpActionResult DeleteAllStatsByGameId(int id)
        {
            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
            var affectedRows = new SqlParameter("@intResult", System.Data.SqlDbType.Int);
            affectedRows.Direction = System.Data.ParameterDirection.Output;
            try
            {                
                var records = db.Fetch<Stat>(";EXEC DeleteAllStatsByGameId @0, @1 OUTPUT", id, affectedRows);                
            }
            catch (System.Exception exception)
            {
                return Content(System.Net.HttpStatusCode.BadRequest, exception);
            }

            return Ok(affectedRows.Value);
        }

        [System.Web.Mvc.HttpGet]        
        public JsonResult<List<Stat>> GetAll()
        {
            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
            var result = db.Fetch<Stat>(new Sql()
                                              .Select("*")
                                              .From("Stats"));
            return Json(result);
        }

        [System.Web.Mvc.HttpGet]
        [System.Web.Mvc.Route("/umbraco/backoffice/api/stats/getstatsbygameid/{id}")]
        public JsonResult<List<StatsInGameRelation>> GetStatsByGameId(int id)
        {
            UmbracoDatabase db = ApplicationContext.DatabaseContext.Database;
            var records = db.Fetch<StatsInGameRelation>(";EXEC GetStatsByGameId @0", id);
            return Json(records);
        }
    }
}