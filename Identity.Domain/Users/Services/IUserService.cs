using Identity.Domain.Utils.interfaces;

namespace Identity.Domain.Users.Services
{
    public interface IUserService : IService<User>
    {
        bool ExistsByEmail(string email);
        User GetByEmail(string email);
    }
}
