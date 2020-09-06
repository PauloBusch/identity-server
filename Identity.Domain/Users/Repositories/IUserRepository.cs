using Identity.Domain.Utils.Interfaces;
using System.Threading.Tasks;

namespace Identity.Domain.Users.Repositories
{
    public interface IUserRepository : IRepository<User> { 
        Task<bool> ExistByEmailAsync(string email);
    }
}
