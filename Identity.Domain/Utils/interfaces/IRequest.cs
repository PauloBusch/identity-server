using Identity.Domain.Utils.Responses;
using System.Threading.Tasks;

namespace Identity.Domain.Utils.Interfaces
{
    public interface IRequest
    {
        Task<Response> ValidateAsync();
        Task<Response> ExecuteAsync();
    }
}
