﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityApp.Web.Security
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="extraClaims"></param>
        /// <returns></returns>
        void LogIn(IUserAuthData user, bool isPersistant, params Claim[] extraClaims);

        /// <summary>
        /// Logs out the currently signed in user
        /// </summary>
        void LogOut();


        IUserAuthData GetCurrentUser();
    }
}
