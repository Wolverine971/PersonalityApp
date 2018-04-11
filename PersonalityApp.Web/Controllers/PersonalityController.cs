using PersonalityApp.Web.Domain;
using PersonalityApp.Web.Domain.Requests;
using PersonalityApp.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonalityApp.Web.Controllers
{
    [RoutePrefix("api/personality")]
    [AllowAnonymous]
    public class PersonalityController : ApiController
    {
        IPersonalityService _svc;
        IUserService _uSvc;

        public PersonalityController(IPersonalityService svc, UserService uSvc)
        {
            _svc = svc;
            _uSvc = uSvc;
        }
        [Route("SetP"), HttpPost]
        public HttpResponseMessage SetPersonality(int UserId, string Personality)
        {
            _svc.SetPersonality(UserId, Personality);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [Route("GetP"), HttpGet]
        public HttpResponseMessage GetPersonality(int UserId)
        {
            try
            {
                var Personality = _svc.GetPersonality(UserId);
                return Request.CreateResponse(HttpStatusCode.OK, User);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }

        //[Route("loginUser"), HttpPost]
        //public HttpResponseMessage Login(LoginRequest model)
        //{
        //    try
        //    {
        //        var User = _uSvc.LoginUser(model);
        //        return Request.CreateResponse(HttpStatusCode.OK, User);
        //    }
        //    catch(Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}
        [Route("getUsers"), HttpGet]
        public HttpResponseMessage AllUsers()
        {
            try
            {
                var ListOfUsers = _uSvc.GetUsers();
                return Request.CreateResponse(HttpStatusCode.OK, ListOfUsers);
              
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
