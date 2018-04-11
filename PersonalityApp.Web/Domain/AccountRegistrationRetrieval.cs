using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain
{
    public class AccountRegistrationRetrieval
    {
        public PersonBase Person { get; set; }
        public List<int> RoleIds { get; set; }
        public string PasswordHash { get; set; }
    }
}