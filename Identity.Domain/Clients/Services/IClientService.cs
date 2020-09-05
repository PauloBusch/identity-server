using Identity.Domain.Apps;
using Identity.Domain.Companies;
using Identity.Domain.Users;
using Identity.Domain.Utils.interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Clients.Services
{
    public interface IClientService : IService<Client>
    {
        Task<bool> UserHasAccess(Guid userId, Guid companyId);
        Task<IEnumerable<Company>> GetCompanies(Guid id);
        Task<IEnumerable<User>> GetUsers(Guid id);
    }
}
