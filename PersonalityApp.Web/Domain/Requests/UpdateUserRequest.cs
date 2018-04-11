using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain.Requests
{
    public class UpdateUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DBO { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Job Job { get; set; }
        public Personality Personality { get; set; }
        public LoveLife LoveLife { get; set; }
    }
}