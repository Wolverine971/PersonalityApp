using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain
{
    public class PersonPhoto
    {
        public int PhotoId { get; set; }
        public string PhotoUrl { get; set; }
        public int PersonId { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsProfilePhoto { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
    }
}