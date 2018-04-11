using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalityApp.Web.Domain
{
    public class ConfirmationEmail
    {
        /// The Domain Keys Identified Email code for the email
        public string Dkim { get; set; }

        /// The email address that the email was sent to
        public string To { get; set; }

        /// The HTML body of the email
        public string Html { get; set; }

        /// The email address the email was sent from
        public string From { get; set; }

        /// The Text body of the email
        public string Text { get; set; }

        /// The Ip address of the sender of the email
        public string SenderIp { get; set; }

        /// A JSON string containing the SMTP envelope. This will have two variables: to, which is an array of recipients, and from, which is the return path for the message.
        public string Envelope { get; set; }

        /// Number of attachments included in email
        public int Attachments { get; set; }

        /// The subject of the email
        public string Subject { get; set; }

        /// A JSON string containing the character sets of the fields extracted from the message.
        public string Charsets { get; set; }

        /// The results of the Sender Policy Framework verification of the message sender and receiving IP address.
        public string Spf { get; set; }
    }
}