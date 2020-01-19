using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Mvc;
using Umbraco.Web.Security;
using ywp.Models.MyAccount;

namespace ywp.Controllers.SiteControllers
{
    public class MyAccountResetPasswordController : SurfaceController
    {
        public ActionResult SubmitReset(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {                
                var currentUser = Membership.GetUser();
                if(Membership.ValidateUser(currentUser.UserName, model.OldPassword))
                {
                    currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                    TempData["success"] = "Ok";
                }               
                else
                {
                    TempData["error"] = "Wrong old pwd";
                }
            }            
            return CurrentUmbracoPage();
        }
    }
}