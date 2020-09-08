using Identity.Data._Common.Repositories;
using Identity.Data.Context;
using Identity.Domain.Entities;
using Identity.Domain.Interfaces.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Identity.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IdentityContext context) : base(context) { }

        public async Task<bool> ExistByEmailAsync(string email, Guid? ignoreId = null)
        {
            return await _context.Users.AnyAsync(u => !u.Id.Equals(ignoreId) && u.Email.Equals(email));
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Users.FirstAsync(u => u.Email.Equals(email));
        }
    }
}
