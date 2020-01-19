using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ywp.Models.SiteModels
{
    /*
     * GAME LOG
     * model is used to store data retrieved from stored procedure
    */
    public class GameLog
    {
        public int Period { get; set; }
        public string Player_Name { get; set; }
        public string Stat_Type_Keyphrase { get; set; }
        public DateTime Stat_Time { get; set; }
    }
}