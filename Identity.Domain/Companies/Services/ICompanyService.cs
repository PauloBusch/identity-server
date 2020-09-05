using Identity.Domain.Users;
using Identity.Domain.Utils.interfaces;
using System;
using System.Threading.Tasks;

namespace Identity.Domain.Companies.Services
{
    public interface ICompanyService : IService<Company>
    {
        Task<User> GetUsers(Guid id);
    }
}
