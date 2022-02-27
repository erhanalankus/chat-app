using ChatApp.Core.CustomExceptions;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace ChatApp.Service
{
    public class EmailSender : IEmailSender
    {
        private readonly ISendGridClient _sendGridClient;

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor, ISendGridClient sendGridClient)
        {
            Options = optionsAccessor.Value;
            _sendGridClient = sendGridClient;
        }

        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(Options.SendGridKey, subject, htmlMessage, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            if (string.IsNullOrWhiteSpace(apiKey) || apiKey.Length < 25)
            {
                throw new InvalidSendgridCredentialsException(Options.SendGridUser);
            }

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(Options.SenderEmail, Options.SendGridUser),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return _sendGridClient.SendEmailAsync(msg);
        }
    }
}
