using Identity.Domain._Common.Enums;
using Identity.Domain._Common.Results;
using Identity.Domain.Dtos.Auth;
using Identity.Domain.Dtos.Users;
using Identity.Domain.Entities;
using Identity.Domain.Interfaces.Repositories.Users;
using Identity.Domain.Interfaces.Services.Users;
using Identity.Domain.Security;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Identity.Service.Users
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly SigningConfig _signingConfig;
        private readonly TokenConfig _tokenConfig;

        public AuthService(
            IUserRepository userRepository,
            SigningConfig signingConfig,
            TokenConfig tokenConfig
        )
        {
            _userRepository = userRepository;
            _signingConfig = signingConfig;
            _tokenConfig = tokenConfig;
        }

        public async Task<Result<TokenDto>> LoginAsync(LoginDto loginDto)
        {
            var errorResult = new Result<TokenDto>(EStatus.Unauthorized, "Email ou senha inválida");
            var exists = await _userRepository.ExistByEmailAsync(loginDto.Email);
            if (!exists) return errorResult;
            var userDb = await _userRepository.FindByEmailAsync(loginDto.Email);
            var token = GenerateTokenAsync(userDb);
            return new Result<TokenDto>(token);
        }

        public TokenDto GenerateTokenAsync(User user) { 
            var identity = new ClaimsIdentity(
                new GenericIdentity(user.Email),
                new [] { 
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
                }
            );

            var created = DateTime.UtcNow;
            var expires = created.AddSeconds(_tokenConfig.Seconds);
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor { 
                Issuer = _tokenConfig.Issuer,
                Audience = _tokenConfig.Audience,
                SigningCredentials = _signingConfig.Credentials,
                Subject = identity,
                NotBefore = created,
                Expires = expires
            });

            var token = handler.WriteToken(securityToken);
            return new TokenDto { 
                Token = token,
                Created = created,
                Expires = expires
            };
        }
    }
}
