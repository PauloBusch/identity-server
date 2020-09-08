﻿using Identity.Domain._Common.Enums;
using Identity.Domain._Common.Results;
using Identity.Domain.Entities;
using Identity.Domain.Interfaces.Repositories.Users;
using Identity.Domain.Interfaces.Services.Users;
using Identity.Domain.Pcos.Users;
using System.Threading.Tasks;

namespace Identity.Service.Users
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<object>> LoginAsync(LoginDto loginDto)
        {
            var defaultMessage = "Falha ao realizar login";
            var exists = await _userRepository.ExistByEmailAsync(loginDto.Email);
            if (!exists) return new Result<object>(EStatus.Unauthorized, nameof(loginDto.Email), defaultMessage);
            var userDb = await _userRepository.FindByEmailAsync(loginDto.Email);
            return new Result<object>(userDb);
        }

        public async Task<string> GenerateTokenAsync(User user) { 
            return "";    
        }
    }
}
