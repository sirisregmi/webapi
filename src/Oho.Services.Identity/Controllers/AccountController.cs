using System.Threading.Tasks;
using Oho.Services.Identity.Services;
using Microsoft.AspNetCore.Mvc;
using Oho.Common.Commands;
using Oho.Services.Identity.Messages.Command;

//using Oho.Common.Commands;

namespace Oho.Services.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(SignIn command)
        => Ok(await userService.LoginAsync(command.Email, command.Password));

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(SignUp command)
        => Ok(await userService.RegisterAsync(command.FirstName, command.LastName, command.Email, command.Password));
    }
}