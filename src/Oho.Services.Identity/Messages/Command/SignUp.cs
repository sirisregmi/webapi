using System;

namespace Oho.Services.Identity.Messages.Command
{
    public class SignUp
    {
        public string FirstName{get;set;}
        public string LastName{get;set;}
        public string Email { get;set; }
        public string Password { get; set;}
        
    }
}
