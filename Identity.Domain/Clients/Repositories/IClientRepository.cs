using Identity.Domain.Apps;
using Identity.Domain.Companies;
using Identity.Domain.Users;
using Identity.Domain.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Clients.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<bool> UserHasAccessAsync(Guid userId, Guid companyId);
        Task<IEnumerable<Company>> GetCompaniesAsync(Guid id);
        Task<IEnumerable<User>> GetUsersAsync(Guid id);
    }
}
