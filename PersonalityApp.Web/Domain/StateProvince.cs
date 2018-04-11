using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain
{
    public class StateProvince
    {
        public int Id { get; set; }
        public string StateProvinceCode { get; set; }
        public string Name { get; set; }
        public string CountryRegionCode { get; set; }

    }
}