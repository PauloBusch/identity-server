using Identity.Domain.Users;
using Identity.Domain.Utils.interfaces;
using System;
using System.Threading.Tasks;

namespace Identity.Domain.Companies.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Task<User> GetUsers(Guid id);
    }
}
