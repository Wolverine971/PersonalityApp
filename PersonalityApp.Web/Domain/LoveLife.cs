using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain
{
    public class LoveLife
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public RelationshipStatus RelationshipStatus { get; set; }
        public int LengthOfStatus { get; set; }
        public Partner Partner { get; set; }
        public LoveMakingPreference LoveMakingPreference { get; set; }
    }
}