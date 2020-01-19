using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
current model is used to store the result set of Stats-Games-Rosters-StatTypes join.
used in backoffice Stats->Uploaded stats tab.
*/

namespace ywp.Models
{
    public class StatsInGameRelation
    {
        [Column("Stat_Id")]
        public int Stat_Id { get; set; }

        [Column("Game_Id")]
        public int Game_Id { get; set; }

        [Column("Opposing_Team")]
        public string Opposing_Team { get; set; }

        [Column("Player_Name")]
        public string Player_Name { get; set; }

        [Column("Player_Id")]
        public int Player_Id { get; set; }

        [Column("Period")]
        public int Period { get; set; }

        [Column("Stat_Type_Keyphrase")]
        public string Stat_Type_Keyphrase { get; set; }

        [Column("Stat_Time")]
        public DateTime Stat_Time { get; set; }
    }
}