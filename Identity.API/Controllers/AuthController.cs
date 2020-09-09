using Identity.Domain._Common.Results;
using Identity.Domain.Dtos.Auth;
using Identity.Domain.Dtos.Users;
using Identity.Domain.Interfaces.Services.Users;
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
        public async Task<Result<TokenDto>> LoginAsync([FromBody] LoginDto loginDto)
        {
            return GetResult(await  _authService.LoginAsync(loginDto));
        }

        [HttpGet("logout")]
        public Result Logout()
        {
            return GetResult(new Result());
        }
    }
}
