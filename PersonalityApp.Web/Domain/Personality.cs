using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web
{
    public class Personality
    {
        public int Id { get; set; }
        public string MBTI { get; set; }
        public string Role { get; set; }
        public string Strategy { get; set; }
        public string Name { get; set; }
    }
}