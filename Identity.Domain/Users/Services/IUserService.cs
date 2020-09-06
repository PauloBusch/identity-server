using Identity.Domain.Users.Dtos;
using Identity.Domain.Utils.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Users.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> GetAsync(Guid id);
        Task<IEnumerable<UserResponseDto>> GetAllAsync();
        Task<Response> CreateAsync(UserRequestDto userDto);
        Task<Response> UpdateAsync(UserRequestDto userDto);
        Task<Response> DeleteAsync(Guid id);
    }
}
