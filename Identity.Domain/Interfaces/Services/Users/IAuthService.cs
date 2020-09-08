using Identity.Domain._Common.Results;
using Identity.Domain.Entities;
using Identity.Domain.Pcos.Users;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces.Services.Users
{
    public interface IAuthService
    {
        Task<Result<object>> LoginAsync(LoginDto loginDto);
        Task<string> GenerateTokenAsync(User user);
    }
}
