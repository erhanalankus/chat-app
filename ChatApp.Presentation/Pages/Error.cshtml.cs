using ChatApp.Core.CustomExceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ChatApp.Presentation.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string ExceptionMessage { get; set; }

        private readonly ILogger<ErrorModel> _logger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        private void AddInvalidSendgridCredentialsExceptionMessageToModel()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            if (exceptionHandlerPathFeature?.Error is InvalidSendgridCredentialsException)
            {
                ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
            }
        }

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            AddInvalidSendgridCredentialsExceptionMessageToModel();
            _logger.LogError(ExceptionMessage);
        }

        public void OnPost()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            AddInvalidSendgridCredentialsExceptionMessageToModel();
            _logger.LogError(ExceptionMessage);
        }
    }
}
