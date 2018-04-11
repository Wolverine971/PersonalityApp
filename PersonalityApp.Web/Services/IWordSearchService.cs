using PersonalityApp.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WordsAPI.Model;

namespace PersonalityApp.Web.Services
{
    public interface IWordSearchService
    {
        DetailsResponse GetWordDefinitions(WordRequest model);
        DetailsResponse GetWordSynonyms(WordRequest model);
    }
}