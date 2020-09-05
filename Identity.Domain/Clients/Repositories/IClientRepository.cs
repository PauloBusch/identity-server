using Identity.Domain.Apps;
using Identity.Domain.Companies;
using Identity.Domain.Users;
using Identity.Domain.Utils.interfaces;
using System;
using System.Threading.Tasks;

namespace Identity.Domain.Clients.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<bool> UserHasAccess(Guid userId, Guid companyId);
        Task<Company> GetCompanies(Guid id);
        Task<User> GetUsers(Guid id);
    }
}
