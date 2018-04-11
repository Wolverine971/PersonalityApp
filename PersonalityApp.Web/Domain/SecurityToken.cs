using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain
{
    public class SecurityToken
    {
        public Guid GUID { get; set; }
        public string UserEmail { get; set; }
        public int TokenTypeId { get; set; }
        public DateTime DateCreated { get; set; }
        public string LinkStatus { get; set; }
    }
}
