using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace ywp.Models
{
    [TableName("Rosters")]
    [PrimaryKey("Player_Id", autoIncrement = true)]
    public class Roster
    {
        [Column("Player_Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Player_Id { get; set; }

        [Column("Player_Name")]
        public String Player_Name { get; set; }

        [Column("Player_Dob")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public DateTime Player_Dob { get; set; }

        [Column("Player_Cap_Number")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public int Player_Cap_Number { get; set; }

        [Column("Player_Start_Date")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public DateTime Player_Start_Date { get; set; }

        [Column("Player_End_Date")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public DateTime Player_End_Date { get; set; }

        [Column("Player_Position")]
        [NullSetting(NullSetting = NullSettings.Null)]
        public String Player_Position { get; set; }
    }
}