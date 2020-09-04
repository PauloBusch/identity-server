using Identity.Domain.Utils.Responses;
using System.Threading.Tasks;

namespace Identity.Domain.Utils.interfaces
{
    public interface IUnitOfWork
    {
        Task<Response> CommitAsync();
    }
}
