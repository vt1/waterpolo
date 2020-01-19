using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Web.WebApi;
using ywp.Models;
using System.Web.Http.Results;

namespace ywp.Controllers
{
    public class MembersController : UmbracoAuthorizedApiController
    {
        //get all members from DEFAULT umbraco table 'cmsMember'
        [HttpGet]
        public JsonResult<List<MemberModel>> GetAllMembers()
        {
            int totalRecords;
            var members = ApplicationContext.Current.Services.MemberService.GetAll(0, int.MaxValue, out totalRecords);
            var memberModel = new List<MemberModel>();
            foreach(var member in members)
            {
                memberModel.Add(new MemberModel()
                {                    
                    Node_Id = member.Id,
                    Email = member.Email,
                    IsApproved = member.IsApproved,
                    Name = member.Name,
                    UserName = member.Username
                });
            }
            return Json(memberModel);            
        }
    }
}