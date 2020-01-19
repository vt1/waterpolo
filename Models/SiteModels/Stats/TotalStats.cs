using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ywp.Models.SiteModels.Stats
{
    /*
     * Total stats
     * model is used to store data retrieved from stored procedure
    */
    public class TotalStats
    {
        public int Player_Id { get; set; }
        public string Player_Name { get; set; }
        public int Stat_Type_Id { get; set; }
        public string Stat_Type { get; set; }
        public int Score { get; set; }
    }
}