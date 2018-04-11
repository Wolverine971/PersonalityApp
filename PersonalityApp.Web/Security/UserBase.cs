using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Security
{
    public class UserBase : IUserAuthData
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhotoUrl { get; set; }

        public List<string> Roles { get; set; }
    }
}