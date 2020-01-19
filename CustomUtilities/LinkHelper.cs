using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ywp.CustomUtilities
{
    public class LinkHelper
    {
        public static MvcHtmlString Link(string url, string text)
        {            
            return MvcHtmlString.Create(String.Format("<a href='{0}'>{1}</a>", url, text));
        }        
    }
}