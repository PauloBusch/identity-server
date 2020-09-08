using Identity.Domain._Common.Enums;
using Identity.Domain._Common.Results;
using Identity.Domain.Entities;
using Identity.Domain.Interfaces.Repositories.Users;
using Identity.Domain.Interfaces.Services.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> CreateAsync(User user)
        {
            var existEmail = await _userRepository.ExistByEmailAsync(user.Email);
            if (existEmail) return new Result(EStatus.Conflict, "Já existe um usuário com esse email");
            await _userRepository.CreateAsync(user);
            return new Result();
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var exist = await _userRepository.ExistByIdAsync(id);
            if (!exist) return new Result(EStatus.NotFund, "Usuário com esse id não existe");
            await _userRepository.DeleteAsync(id);
            return new Result();
        }

        public async Task<IEnumerable<User>> AllAsync()
        {
            return await _userRepository.AllAsync();
        }

        public async Task<Result<User>> FindByIdAsync(Guid id)
        {
            var exist = await _userRepository.ExistByIdAsync(id);
            if (!exist) return new Result<User>(EStatus.NotFund, "Usuário com esse id não existe");
            var user = await _userRepository.FindByIdAsync(id);
            return new Result<User>(user);
        }

        public async Task<Result> UpdateAsync(User user)
        {
            var exist = await _userRepository.ExistByIdAsync(user.Id);
            if (!exist) return new Result(EStatus.NotFund, "Usuário com esse id não existe");
            var existEmail = await _userRepository.ExistByEmailAsync(user.Email, user.Id);
            if (existEmail) return new Result(EStatus.Conflict, "Já existe um usuário com esse email");
            await _userRepository.UpdateAsync(user);
            return new Result();
        }
    }
}
