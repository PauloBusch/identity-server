using Identity.Domain._Common.Results;
using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces.Services.Users
{
    public interface IUserService
    {
        Task<Result<User>> FindByIdAsync(Guid id);
        Task<IEnumerable<User>> AllAsync();
        Task<Result> CreateAsync(User user);
        Task<Result> UpdateAsync(User user);
        Task<Result> DeleteAsync(Guid id);
    }
}
