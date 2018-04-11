using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Responses
{
    public class ItemResponse<T> : SuccessResponse
        {
            public T Item { get; set; }
        }
    }