using System;

namespace ChatApp.Core.CustomExceptions
{
    public class InvalidSendgridCredentialsException : Exception
    {
        public InvalidSendgridCredentialsException()
        {

        }

        public InvalidSendgridCredentialsException(string sendgridUsername)
            : base(String.Format("Invalid SendGrid credentials. This is the SendGrid username that you supplied: {0}." +
                " Please see the README for information on how to provide SendGrid credentials." +
                "You can contact me at +905553989095 for my SendGrid credentials." +
                "If you prefer, you can use the deployed version with the same code at: LINK", sendgridUsername))
        {

        }
    }
}
