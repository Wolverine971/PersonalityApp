using PersonalityApp.Web.Domain.Requests;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace PersonalityApp.Web.Services
{
    public class ConfirmationEmailService
    {
        public async Task<bool> Execute(ConfirmationEmailRequest model)
        {
            var apiKey = ConfigurationManager.AppSettings["djKey"].ToString(); //Grab Key From Web.Config
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("djwayne3@gmail.com");
            var subject = model.Subject;
            var to = new EmailAddress(model.To);
            var plainTextContent = model.Body;
            var htmlContent = model.Body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            SendGrid.Response response = await client.SendEmailAsync(msg);
            if (response.StatusCode == HttpStatusCode.Accepted || response.StatusCode == HttpStatusCode.OK)
            { return true; }
            return false;
        }
    }
}