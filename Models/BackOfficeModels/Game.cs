using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace ywp.Models
{
    [TableName("Games")]
    [PrimaryKey("Game_Id", autoIncrement = true)]
    public class Game
    {
        [Column("Game_Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Game_Id { get; set; }

        [Column("Season_Id")]
        public int Season_Id { get; set; }

        [Column("Opposing_Team")]
        public String Opposing_Team { get; set; }

        [Column("Game_Date")]
        public DateTime Game_Date { get; set; }

        [Column("Game_Location")]
        public String Game_Location { get; set; }
    }
}