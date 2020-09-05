using Identity.Domain.Utils.interfaces;
using System.Threading.Tasks;

namespace Identity.Domain.Users.Services
{
    public interface IUserService : IService<User>
    {
        bool ExistsByEmail(string email);
        User GetByEmail(string email);
    }
}
