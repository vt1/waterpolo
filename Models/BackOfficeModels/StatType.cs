using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace ywp.Models
{
    [TableName("StatTypes")]
    [PrimaryKey("Stat_Type_Id", autoIncrement = true)]
    public class StatType
    {
        [Column("Stat_Type_Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Stat_Type_Id { get; set; }

        [Column("Stat_Type")]
        public String Stat_Type { get; set; }

        [Column("Stat_Type_Description")]
        public String Stat_Type_Description { get; set; }

        [Column("Stat_Type_Keyphrase")]
        public String Stat_Type_Keyphrase { get; set; }

        [Column("Stat_Type_Webview")]
        public String Stat_Type_Webview { get; set; }        
    }
}