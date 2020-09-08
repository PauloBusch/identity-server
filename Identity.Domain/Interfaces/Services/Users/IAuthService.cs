using Identity.Domain._Common.Results;
using Identity.Domain.Entities;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces.Services.Users
{
    public interface IAuthService
    {
        Task<Result<object>> LoginAsync(User user);
        Task<string> GenerateTokenAsync(User user);
    }
}
