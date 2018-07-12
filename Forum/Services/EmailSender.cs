using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Forum.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender()
        {
            
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute("SG.KEYHERE", subject, message, email);
            //return Execute(Options.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("no-reply@cortez.ph", "Cortez.ph"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
    }
}
