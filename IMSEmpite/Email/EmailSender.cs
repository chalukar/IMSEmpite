using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMSEmpite.Email
{
    public class EmailSender : IEmailSender
    {
        public EmailOptions Option { get; set; }

        public EmailSender(IOptions<EmailOptions> emailOptions)
        {
            Option = emailOptions.Value;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient(Option.SendGridKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("chaluka.rathnayaka@gmail.com","Inventory Management System-Empite"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };
            msg.AddTo(new EmailAddress(email));

            try
            {
                return client.SendEmailAsync(msg);
            }
            catch(Exception ex)
            {

            }
            return null;
        }
    }
}
