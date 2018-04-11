using PersonalityApp.Web.Domain;
using PersonalityApp.Web.Domain.Requests;
using PersonalityApp.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PersonalityApp.Web.Controllers
{
    [RoutePrefix("api/SecurityToken")]
    public class SecurityTokenApiController : ApiController
    {

        SecurityTokenService _svc;

        public SecurityTokenApiController(SecurityTokenService svc)
        {
            _svc = svc;
        }
        //INSERT
        [Route]
        [HttpPost]
        public HttpResponseMessage Insert(SecurityTokenAddRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            Guid response = new Guid();
            response = _svc.Insert(model);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        //GET BY ID
        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage SelectById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            SecurityToken response = new SecurityToken();
            response = _svc.SelectById(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        //Update
        [Route("{id:Guid}")]
        [HttpPut]
        public HttpResponseMessage Update(SecurityTokenUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            _svc.UpdateLinkStatus(model);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}