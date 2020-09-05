using Identity.Domain.Utils.Interfaces;

namespace Identity.Domain.Users.Services
{
    public interface IUserService : IService<User>
    {
        bool ExistsByEmail(string email);
        User GetByEmail(string email);
    }
}
