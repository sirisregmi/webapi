using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oho.Common.Exceptions;
using Oho.Services.Identity.Domain.Services;
using System.ComponentModel.DataAnnotations;
namespace Oho.Services.Identity.Domain.Models
{
    [Table("tb_users")]
    public class User
    {
        [Key]
        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        { }

        public User(string firstname, string lastname, string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new OhoException("empty_user_email", "User email can not be null");
            }

            if (string.IsNullOrWhiteSpace(firstname))
            {
                throw new OhoException("empty_user_name", "First name can not be null");
            }

            this.Id = Guid.NewGuid();
            this.Email = email.ToLowerInvariant();
            this.FirstName = firstname;
            this.LastName = lastname;
            this.CreatedAt = DateTime.Now;
        }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new OhoException("empty_user_password", "User password can not be null");
            }

            this.Salt = encrypter.GetSalt(password);
            this.Password = encrypter.GetHash(password, this.Salt);
        }

        public bool ValidatePassword(string password, IEncrypter encrypter)
            => this.Password.Equals(encrypter.GetHash(password, this.Salt));
    }
}