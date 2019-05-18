
using Oho.Services.Identity.Domain.Models;
using System;
using System.Threading.Tasks;
namespace Oho.Services.Identity.Repo
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);

        void Save();
    }
}