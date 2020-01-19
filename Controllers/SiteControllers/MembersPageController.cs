using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Persistence;
using Umbraco.Web.Mvc;
using ywp.Models;

namespace ywp.Controllers
{
    public class MembersPageController : RenderMvcController
    {     
        public ActionResult MembersPage()
        {            
            return View();
        }        
    }
}