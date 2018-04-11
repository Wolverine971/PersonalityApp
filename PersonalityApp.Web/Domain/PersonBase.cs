using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain
{
    public class PersonBase
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string PhotoUrl { get; set; }
        public string TextNumber { get; set; }
        public string PhoneNumber { get; set; }
        public bool Inactive { get; set; }
    }
}