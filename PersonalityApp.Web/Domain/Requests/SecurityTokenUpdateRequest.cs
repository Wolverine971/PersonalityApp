using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain.Requests
{
    public class SecurityTokenUpdateRequest: SecurityTokenAddRequest
    {
        [Required]
        public Guid GUID { get; set; }
    }
}