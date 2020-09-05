using Identity.Domain.Users;
using Identity.Domain.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Companies.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<IEnumerable<User>> GetUsersAsync(Guid id);
    }
}
