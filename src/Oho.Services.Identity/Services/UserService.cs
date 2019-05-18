using System;
using System.Threading.Tasks;
using Oho.Common.Auth;
using Oho.Common.Exceptions;
using Oho.Services.Identity.Domain.Models;

using Oho.Services.Identity.Domain.Services;
using Oho.Services.Identity.Repo;

namespace Oho.Services.Identity.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IEncrypter encrypter;
        private readonly IJwtHandler jwtHandler;

        public UserService(IUserRepository userRepository,
                           IEncrypter encrypter
                            , IJwtHandler jwtHandler)
        {
            this.userRepository = userRepository;
            this.encrypter = encrypter;
            this.jwtHandler = jwtHandler;
        }

        public async Task<string> RegisterAsync(string firstname, 
                                                string lastname, 
                                                string email, 
                                                string password)
        {
            var user = await this.userRepository.GetAsync(email);
            if (user != null)
                throw new OhoException("email_in_use", $"Email: '{email}' already in use");
    
            user = new User(firstname, lastname, email);
            
            user.SetPassword(password, this.encrypter);

            if (this.userRepository.AddAsync(user).IsCompleted)
                this.userRepository.Save();

            return user.Id.ToString();
        }

        public async Task<JsonWebToken> LoginAsync(string email, string password)
        {
            User user = await this.userRepository.GetAsync(email);

            if (user == null)
            {
                throw new OhoException("invalid_credentials", "Invalid credentials");
            }
            if (!user.ValidatePassword(password, this.encrypter))
            {
                throw new OhoException("invalid_credentials", "Invalid credentials");
            }
            return this.jwtHandler.Create(user.Id);
        }
    }
}