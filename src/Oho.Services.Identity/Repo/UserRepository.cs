
using Microsoft.EntityFrameworkCore;
using Oho.Services.Identity;
using Oho.Services.Identity.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Oho.Services.Identity.Repo
{
    public sealed class UserRepository : IUserRepository
    {

        private IdentityContext db;
        public UserRepository(IdentityContext _db)
        {
            this.db = _db;

        }
        Task IUserRepository.AddAsync(User user) => db.AddAsync(user);

        Task<User> IUserRepository.GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        Task<User> IUserRepository.GetAsync(string email)
        {

            return Task.FromResult(db.Users.Where(x => x.Email == email).SingleOrDefault());

        }
    }
}