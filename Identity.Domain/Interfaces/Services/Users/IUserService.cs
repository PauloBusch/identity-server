using Identity.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Interfaces.Services.Users
{
    public interface IUserService
    {
        Task<User> GetAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
