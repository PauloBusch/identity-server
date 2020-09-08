using Identity.Domain._Common.Results;
using Identity.Domain.Entities;
using Identity.Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    [Route("api/users")]
    public class UsersController : IdentityControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<Result<IEnumerable<User>>> ListAsync()
        {
            return GetResult(await _userService.AllAsync());
        }

        [HttpGet("{id}")]
        public async Task<Result<User>> GetAsync([FromRoute] Guid id)
        {
            return GetResult(await _userService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<Result> CreateAsync([FromBody] User user)
        {
            return GetResult(await _userService.CreateAsync(user));
        }

        [HttpPut("{id}")]
        public async Task<Result> UpdateAsync([FromRoute] Guid id, [FromBody] User user)
        {
            user.Id = id;
            return GetResult(await _userService.UpdateAsync(user));
        }

        [HttpDelete("{id}")]
        public async Task<Result> DeleteAsync([FromRoute] Guid id)
        {
            return GetResult(await _userService.DeleteAsync(id));
        }
    }
}
