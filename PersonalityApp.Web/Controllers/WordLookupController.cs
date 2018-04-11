using PersonalityApp.Web.Domain;
using PersonalityApp.Web.Responses;
using PersonalityApp.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WordsAPI.Model;

namespace PersonalityApp.Web.Controllers
{
    [RoutePrefix("api/word")]
    public class WordLookupController : ApiController
    {
        IWordSearchService _wSvc;

        public WordLookupController(IWordSearchService wSvc)
        {
            _wSvc = wSvc;
        }
        [Route("syn"), HttpPost]
        public HttpResponseMessage FindWordSynonyms(WordRequest model)
        {
            try
            {
                ItemResponse<DetailsResponse> response = new ItemResponse<DetailsResponse>();
                response.Item = _wSvc.GetWordSynonyms(model);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        [Route("def"), HttpPost]
        public HttpResponseMessage FindWordDefinition(WordRequest model)
        {
            try
            {
                ItemResponse<DetailsResponse> response = new ItemResponse<DetailsResponse>();
                response.Item = _wSvc.GetWordDefinitions(model);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        
    }
}