using PersonalityApp.Web.Domain;
using PersonalityApp.Web.Domain.Requests;
using PersonalityApp.Web.Responses;
using PersonalityApp.Web.Security;
using PersonalityApp.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalityApp.Web.Controllers
{
    [RoutePrefix("api/user")]
    public class UserApiController : ApiController
    {
        UserService _svc;
        IAuthenticationService _authService;


        public UserApiController(UserService svc, IAuthenticationService authSvc)
        {
            _svc = svc;
            _authService = authSvc;
        }
        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetUser(int id)
        {
            ItemResponse<User> response = new ItemResponse<User>();
            response.Item = _svc.GetUserById(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }
        [Route("update"), HttpPut]
        public HttpResponseMessage UpdateUser(UpdateUserRequest model)
        {
            var user = _authService.GetCurrentUser();
            ItemResponse<int> response = new ItemResponse<int>();
            response.Item = _svc.UpdateUser(user.Id, model);
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }
        

    }
}