using Identity.Domain.Companies;
using Identity.Domain.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Clients.Services
{
    public interface IClientService
    {
        Task<bool> UserHasAccessAsync(Guid userId, Guid companyId);
        Task<IEnumerable<Company>> GetCompaniesAsync(Guid id);
        Task<IEnumerable<User>> GetUsersAsync(Guid id);
    }
}
