using Identity.Domain.Clients.Repositories;
using Identity.Domain.Companies.Repositories;
using Identity.Domain.Users.Repositories;
using Identity.Domain.Utils.Responses;
using System.Threading.Tasks;

namespace Identity.Domain.Utils.Interfaces
{
    public interface IIdentityUnitOfWork
    {
        IUserRepository Users { get; }
        ICompanyRepository Companies { get; }
        IClientRepository Clients { get; }

        Task<Response> CommitAsync();
    }
}
