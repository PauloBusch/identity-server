using Identity.Domain.Users;
using Identity.Domain.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Companies.Services
{
    public interface ICompanyService : IService<Company>
    {
        Task<IEnumerable<User>> GetUsersAsync(Guid id);
    }
}
