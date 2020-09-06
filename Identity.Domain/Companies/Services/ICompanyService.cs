using Identity.Domain.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Companies.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<UserResponseDto>> GetUsersAsync(Guid id);
    }
}
