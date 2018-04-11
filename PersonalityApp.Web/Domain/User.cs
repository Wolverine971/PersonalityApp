using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DBO { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public Job Job { get; set; }
        public LoveLife LoveLife { get; set; }
        public Personality Personality { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }
}