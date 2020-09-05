using Identity.Domain.Users;
using Identity.Domain.Utils.interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Companies.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<IEnumerable<User>> GetUsers(Guid id);
    }
}
