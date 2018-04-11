using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain
{
    public class Partner
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public Job Job { get; set; }
        public Personality Personality { get; set; }

    }
}