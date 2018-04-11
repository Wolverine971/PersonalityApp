using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PersonalityApp.Web.Security
{
    public class OwinAuthenticationService: IAuthenticationService
    {
        private static string _title = null;
        // Sabio.Models.Domain.UserBase _baseUser = null;
        static OwinAuthenticationService()
        {
            _title = GetApplicationName();
        }

        public OwinAuthenticationService()
        {

        }

        public void LogIn(IUserAuthData user, bool isPersistent, params Claim[] extraClaims)
        {
            ClaimsIdentity identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie
                                                            , ClaimsIdentity.DefaultNameClaimType
                                                            , ClaimsIdentity.DefaultRoleClaimType);

            identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider"
                                , _title
                                , ClaimValueTypes.String));

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String));
            identity.AddClaim(new Claim(ClaimsIdentity.DefaultNameClaimType, user.FirstName, ClaimValueTypes.String));



            if (user.Roles != null && user.Roles.Any())
            {
                foreach (string singleRole in user.Roles)
                {
                    identity.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, singleRole, ClaimValueTypes.String));
                }

            }

            identity.AddClaims(extraClaims);

            Microsoft.Owin.Security.AuthenticationProperties props = new Microsoft.Owin.Security.AuthenticationProperties
            {
                IsPersistent = isPersistent,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddDays(60),
                AllowRefresh = true
            };

            HttpContext.Current.GetOwinContext().Authentication.SignIn(props, identity);
        }

        public void LogOut()
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut();
        }


        public IUserAuthData GetCurrentUser()
        {
            return HttpContext.Current.User.Identity.GetCurrentUser();
        }

        private static string GetApplicationName()
        {
            var entryAssembly = Assembly.GetExecutingAssembly();

            var titleAttribute = entryAssembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false).FirstOrDefault() as AssemblyTitleAttribute;
            //if (string.IsNullOrWhiteSpace(applicationTitle))
            //{
            //    applicationTitle = entryAssembly.GetName().Name;
            //}
            return titleAttribute == null ? entryAssembly.GetName().Name : titleAttribute.Title;

        }
    }
}
