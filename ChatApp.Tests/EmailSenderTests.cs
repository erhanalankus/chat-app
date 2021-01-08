using ChatApp.Core.CustomExceptions;
using ChatApp.Service;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace ChatApp.Tests
{
    [TestClass]
    public class EmailSenderTests
    {

        [TestMethod]
        public async Task EmptyStringApiKeyThrowsInvalidSendgridCredentialsExceptionAsync()
        {
            var options = Options.Create(new AuthMessageSenderOptions());
            options.Value.SendGridUser = "Erhan Alankus";
            options.Value.SendGridKey = "";
            var _emailSender = new EmailSender(options);

            await Assert.ThrowsExceptionAsync<InvalidSendgridCredentialsException>(() => _emailSender.SendEmailAsync("","",""));
        }

        [TestMethod]
        public async Task NullApiKeyThrowsInvalidSendgridCredentialsException()
        {
            var options = Options.Create(new AuthMessageSenderOptions());
            options.Value.SendGridUser = "Erhan Alankus";
            options.Value.SendGridKey = null;
            var _emailSender = new EmailSender(options);

            await Assert.ThrowsExceptionAsync<InvalidSendgridCredentialsException>(() => _emailSender.SendEmailAsync("", "", ""));
        }

        [TestMethod]
        public async Task LessThan25CharacterApiKeyThrowsInvalidSendgridCredentialsException()
        {
            var options = Options.Create(new AuthMessageSenderOptions());
            options.Value.SendGridUser = "Erhan Alankus";
            options.Value.SendGridKey = "{REDACTED-APIKEY}";
            var _emailSender = new EmailSender(options);

            await Assert.ThrowsExceptionAsync<InvalidSendgridCredentialsException>(() => _emailSender.SendEmailAsync("", "", ""));
        }
    }
}
