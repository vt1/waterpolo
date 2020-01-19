using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace ywp.Models.SiteViewModels
{
    public class SeasonViewModel : RenderModel
    {
        public SeasonViewModel(IPublishedContent content) : base(content) { }        
        public List<Season> Seasons { get; set; }
    }
}