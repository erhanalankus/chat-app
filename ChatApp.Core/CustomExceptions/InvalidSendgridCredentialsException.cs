﻿using System;

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
                "You can contact me at erhanalankus@gmail.com for support.", sendgridUsername))
        {

        }
    }
}
