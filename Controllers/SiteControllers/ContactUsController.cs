using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using ywp.CustomUtilities;
using ywp.Models.SiteModels;

namespace ywp.Controllers.SiteControllers
{
    public class ContactUsController : SurfaceController
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitContactUs(ContactUsModel model, string returnUrl)
        {            
            if (ModelState.IsValid)
            {
                Mailer mailer = new Mailer();
                try
                {
                    mailer.SendMessage(model.Email, model.Email, mailer.smtpSection.Network.UserName, "WaterPolo contact form", model.Message);
                    TempData["success"] = "Your message is succesfully delivered";                    
                }
                catch(Exception ex)
                {
                    TempData["error"] = ex.Message;
                }                
            }
            else
            {
                TempData["error"] = "All fields required";
            }
            return Redirect("#contact-us");
        }
    }
}