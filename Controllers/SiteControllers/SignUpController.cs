using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;
using ywp.Models;

namespace ywp.Controllers
{
    public class SignUpController : SurfaceController
    {
        public ActionResult RenderSignUpForm()
        {
            return PartialView("_SignUp", new SignUpModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitSignUp(SignUpModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                if(!MemberExists(model.Email))
                {
                    var newMember = Services.MemberService.CreateMember(model.Username, model.Email, model.Name, "Member");
                    try
                    {
                        newMember.IsApproved = false;
                        Services.MemberService.Save(newMember);
                        Services.MemberService.SavePassword(newMember, model.Password);
                        TempData["success"] = "account created. you can login when adm check it";
                    }
                    catch(Exception ex)
                    {
                        TempData["error"] = "Error: Password length min 3 characters";
                    }
                }
                else
                {                    
                    TempData["error"] = "Error: member already exists";
                }
            }
            //show same page with model validation errors
            return CurrentUmbracoPage();
        }

        public bool MemberExists(string email)
        {
            return (Services.MemberService.GetByEmail(email) != null);
        }
    }
}