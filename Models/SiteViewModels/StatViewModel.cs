using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;
using ywp.Models.SiteModels;
using ywp.Models.SiteModels.Stats;

namespace ywp.Models.SiteViewModels
{
    public class StatViewModel : RenderModel
    {
        public StatViewModel(IPublishedContent content) : base(content) { }

        // Game Log
        public List<GameLogPeriod> GameLogPeriod { get; set; }
        public Game Game { get; set; }

        // Totals stat
        public List<RosterStats> RosterStats { get; set; }
        public List<StatType> StatTypes { get; set; }
        public List<GameTotalsScore> GameTotalsScore { get; set; }
    }
}