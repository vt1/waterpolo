using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ywp.Models.SiteModels
{
    public class ForgotPasswordModel
    {
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }
    }
}