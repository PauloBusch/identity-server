using Identity.Domain._Common.Results;
using Identity.Domain.Dtos.Auth;
using Identity.Domain.Dtos.Users;
using Identity.Domain.Entities;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces.Services.Users
{
    public interface IAuthService
    {
        Task<Result<TokenDto>> LoginAsync(LoginDto loginDto);
        TokenDto GenerateTokenAsync(User user);
    }
}
