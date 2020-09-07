using Identity.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces.Repositories.Users
{
    public interface IUserRepository : IRepository<User> {
        Task<bool> ExistByEmailAsync(string email, Guid? ignoreId = null);    
    }
}
