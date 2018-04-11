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
using System.Web;
using System.Web.Http;

namespace Sabio.Web.Controllers.Api
{
    [RoutePrefix("api/accounts")]
    public class AccountsApiController : ApiController
    {
        IAccountService _svc;
        OwinAuthenticationService _oas;

        public AccountsApiController(AccountService svc, OwinAuthenticationService oas)
        {
            _svc = svc;
            _oas = oas;
        }
        [Route("login"), HttpPost]
        public HttpResponseMessage LogIn(LoginRequest model)
        {
            ItemResponse<bool> response = new ItemResponse<bool>();
            response.Item = _svc.LogIn(model.Email, model.Password, model.IsPersistent);

            if (response.Item == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, response);
            }
        }
        [Route("register"), HttpPost]
        public HttpResponseMessage Register(AccountUpsertRequest model)
        {
            _svc.RegisterUser(model);
            ItemResponse<int> response = new ItemResponse<int>();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [Route("{email}"), HttpGet]
        public HttpResponseMessage Existing(string email)
        {
            ItemResponse<AccountRegistrationRetrieval> response = new ItemResponse<AccountRegistrationRetrieval>();
            response.Item = _svc.GetName(email);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [Route("logout"), HttpGet]
        public HttpResponseMessage Logout()
        {
            ItemResponse<IUserAuthData> response = new ItemResponse<IUserAuthData>();
            _oas.LogOut();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        [Route("user"), HttpGet]
        public HttpResponseMessage LoggedInUser()
        {
            ItemResponse<IUserAuthData> response = new ItemResponse<IUserAuthData>();
            response.Item = _oas.GetCurrentUser();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        //for password reset
        [Route("check/{email}/"), HttpGet]
        public HttpResponseMessage CheckConfirmation(string email)
        {
            ItemResponse<User> response = new ItemResponse<User>();
            response.Item = _svc.ForgotPasswordValidateAccount(email);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        //sends forgotten pass email and inserts security token type 2
        [Route("{email}"), HttpPost]
        public HttpResponseMessage ForgottenTokenAndEmail(ForgottenPasswordEmailTokenAddRequest model)
        {
            ItemResponse<string> response = new ItemResponse<string>();
            response.Item = _svc.ForgotPasswordSendEmail(model);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{email}"), HttpPut]
        public HttpResponseMessage UpdatePassword(AccountPasswordResetUpdateRequest model)
        {
            ItemResponse<string> response = new ItemResponse<string>();
            response.Item = _svc.UpdatePassword(model);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}