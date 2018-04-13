using Domain.WordModel;
using PersonalityApp.Web.Domain;
using PersonalityApp.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace PersonalityApp.Web.Controllers
{
    [RoutePrefix("api/word")]
    public class WordController : ApiController
    {
        //response = unirest.get("https://wordsapiv1.p.mashape.com/words/soliloquy",
        //  headers={
        //    "X-Mashape-Key": "<required>",
        //    "Accept": "application/json"
        //  })
            private IWordSearchService _wSS;

        public WordController(IWordSearchService wSS)
        {
            _wSS = wSS;
        }
        [Route("syn"), HttpPost]
        //use a post to go and look up word in model
        public HttpResponseMessage Post(WordRequest model)
        {
            try
            {
                List<DetailsResponse> response = new List<DetailsResponse>();
                response = _wSS.GetSynonyms(model);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}