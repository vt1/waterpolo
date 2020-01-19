using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ywp.Models.SiteModels
{
    // model is used to show game log stat
    public class GameLogPeriod
    {
        public int Period { get; set; }
        public List<GameLog> GameLog { get; set; }

        public GameLogPeriod()
        {
            GameLog = new List<GameLog>();
        }
    }
}