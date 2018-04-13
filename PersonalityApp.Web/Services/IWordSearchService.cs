using PersonalityApp.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Domain.WordModel;

namespace PersonalityApp.Web.Services
{
    public interface IWordSearchService
    {
        List<DetailsResponse> GetSynonyms(WordRequest model);
        string GetResponse(WebRequest client);
    }
}