using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace ywp.Models.SiteViewModels
{
    public class GameViewModel : RenderModel
    {
        public GameViewModel(IPublishedContent content) : base(content) { }
        public List<Game> Games { get; set; }
        public Game GameInfo { get; set; }
        public Season Season { get; set; }
    }
}