﻿namespace WPFDemo.Infrastructure.ServerInteraction
{
    public class SignUpArgs
    {
        public string SessionId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string VerificationCode { get; set; }
    }

    public class LoginArgs
    {
        public string Account { get; set; }

        public string Password { get; set; }
    }
}
