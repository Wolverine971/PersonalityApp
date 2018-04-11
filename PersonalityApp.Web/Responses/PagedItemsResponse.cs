using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Responses
{
    public class PagedItemsResponse<T> : ItemsResponse<T>
    {
        // Items that met search criteria
        public int ItemCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        //  public int TotalResultCount { get; set; }

        public int Pages
        {
            get
            {
                return (int)Math.Ceiling((double)ItemCount / ItemsPerPage);
            }
        }
    }
}