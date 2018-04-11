using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain
{
    public class Job
    {
        public int Id { get; set; }
        public string JobStatus { get; set; }
        public string JobTitle { get; set; }
        public string Industry { get; set; }
        public int YearsExperience { get; set; }
    }
}