using Identity.Domain.Companies.Repositories;
using Identity.Domain.Users.Repositories;
using Identity.Domain.Utils.Responses;
using System.Threading.Tasks;

namespace Identity.Domain.Utils.interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ICompanyRepository Companies { get; }

        Task<Response> CommitAsync();
    }
}
