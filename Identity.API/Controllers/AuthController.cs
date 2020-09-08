using Identity.Domain._Common.Results;
using Identity.Domain.Entities;
using Identity.Domain.Interfaces.Services.Users;
using Identity.Domain.Pcos.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    [Route("api/auth")]
    public class AuthController : IdentityControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<Result<object>> LoginAsync([FromBody] LoginDto loginDto)
        {
            return GetResult(await  _authService.LoginAsync(loginDto));
        }

        [HttpGet("logout")]
        public Result<object> Logout()
        {
            return GetResult(new Result());
        }
    }
}
