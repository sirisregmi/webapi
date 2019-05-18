using System;

namespace Oho.Services.Identity.Messages.Command
{

    public class SignIn
    {
        public string Email { get; }
        public string Password { get; }
    }
}