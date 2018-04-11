using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain.Requests
{
    public class GetUserRequest
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}