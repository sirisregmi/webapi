using System.Threading.Tasks;
using Oho.Common.Auth;

namespace Oho.Services.Identity.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(string firstname, string lastname, string email, string password);
        Task<JsonWebToken> LoginAsync(string email, string password);
    }
}