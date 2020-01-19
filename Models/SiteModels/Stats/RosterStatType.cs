using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ywp.Models.SiteModels.Stats
{
    /*
     * Total stats
     * custom model is used in order to conveniently display tabular data
    */
    public class RosterStatType
    {
        public int Stat_Type_Id { get; set; }
        public int Score { get; set; }
    }
}