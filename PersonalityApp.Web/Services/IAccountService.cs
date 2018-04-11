using PersonalityApp.Web.Domain;
using PersonalityApp.Web.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalityApp.Web.Services
{
    public interface IAccountService
    {
        bool LogIn(string email, string password, bool isPersistant);
        bool GetEmailConfirmation(string email);
        int RegisterUser(AccountUpsertRequest userModel);
        AccountRegistrationRetrieval GetName(string email);
        User ForgotPasswordValidateAccount(string email);
        string ForgotPasswordSendEmail(ForgottenPasswordEmailTokenAddRequest model);
        string UpdatePassword(AccountPasswordResetUpdateRequest model);
    }
}


