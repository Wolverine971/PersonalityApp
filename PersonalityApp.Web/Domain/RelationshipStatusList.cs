using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain
{
    public class RelationshipStatusList
    {
        public int Single { get; set; }
        public int Dating { get; set; }
        public int CommitedRelationship { get; set; }
        public int Open { get; set; }
        public int Married { get; set; }
        public int ItsComplicated { get; set; }

    }
}