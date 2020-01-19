using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace ywp.Models
{
    [TableName("Stats")]
    [PrimaryKey("Stat_Id", autoIncrement = true)]
    public class Stat
    {
        [Column("Stat_Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Stat_Id { get; set; }

        [Column("Game_Id")]
        public int Game_Id { get; set; }

        [Column("Player_Id")]
        public int Player_Id { get; set; }

        [Column("Period")]
        public int Period { get; set; }

        [Column("Stat_Type_Id")]
        public int Stat_Type_Id { get; set; }

        [Column("Stat_Time")]
        public DateTime Stat_Time { get; set; }
    }
}