using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using ywp.Models.SiteModels;
using System.Web.Security;
using System.Net.Configuration;
using System.Configuration;
using System.Net;
using ywp.CustomUtilities;

namespace ywp.Controllers.SiteControllers
{
    public class ForgotPasswordController : SurfaceController
    {
        public ActionResult RenderForgotPassword()
        {
            return PartialView("_ForgotPassword", new ForgotPasswordModel());
        }

        public ActionResult SubmitReset(ForgotPasswordModel model)
        {
            if(ModelState.IsValid)
            {                
                var memberService = Services.MemberService;                
                var member = memberService.GetByEmail(model.Email);
                
                if (member != null)
                {                    
                    Random random = new Random();
                    string newPassword = Membership.GeneratePassword(8, 0);
                    newPassword = Regex.Replace(newPassword, @"[^a-zA-Z0-9]", m => random.Next(1, 10).ToString());
                    memberService.SavePassword(member, newPassword);
                    Mailer mailer = new Mailer();

                    try
                    {
                        mailer.SendMessage(mailer.smtpSection.From, mailer.smtpSection.From, member.Email, "WaterPolo reset pwd", "Your new pwd: " + newPassword);
                        TempData["success"] = "New password sent to inputed email";
                    }
                    catch (Exception ex)
                    {
                        TempData["error"] = ex.Message;
                    }
                }
                else
                {
                    TempData["error"] = "The email is incorrect";
                }
            }            
            return CurrentUmbracoPage();
        }
    }
}