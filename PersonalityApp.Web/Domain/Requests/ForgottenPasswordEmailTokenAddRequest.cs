using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain.Requests
{
    public class ForgottenPasswordEmailTokenAddRequest
    {
        [Required]
        public string Email { get; set; }
    }
}