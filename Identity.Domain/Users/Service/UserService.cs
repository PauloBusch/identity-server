using Identity.Domain.Users.Repositories;
using Identity.Domain.Utils.Common;
using Identity.Domain.Utils.interfaces;
using System.Linq;

namespace Identity.Domain.Users.Service
{
    public class UserService : ServiceBase<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUnitOfWork uow) : base(uow, uow.Users)
        {
            _userRepository = uow.Users;
        }

        public bool ExistsByEmail(string email)
        {
            return _userRepository.Query()
                .Any(u => u.Email == email);
        }

        public User GetByEmail(string email)
        {
            return _userRepository.Query()
                .FirstOrDefault(u => u.Email == email);
        }
    }
}
