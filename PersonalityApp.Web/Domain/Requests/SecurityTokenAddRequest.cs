using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain.Requests
{
    public class SecurityTokenAddRequest
    {
        [Required]
        public string UserEmail { get; set; }

        public int TokenTypeId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}