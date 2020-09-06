using Identity.Domain.Users.Dtos;
using Identity.Domain.Users.Services;
using Identity.Domain.Utils.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.API.Controllers
{
    public class UsersController : IdentityControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<Response<UserResponseDto>> Get(Guid id)
        {
            return GetResult(await _userService.GetAsync(id));
        }

        [HttpGet]
        public async Task<Response<IEnumerable<UserResponseDto>>> List() { 
            return GetResult(await _userService.GetAllAsync());
        }

        [HttpPost]
        public async Task<Response> Create([FromBody] UserRequestDto userDto)
        {
            return GetResult(await _userService.CreateAsync(userDto));
        }

        [HttpPut("{id}")]
        public async Task<Response> Create([FromRoute] Guid id, [FromBody] UserRequestDto userDto)
        {
            userDto.Id = id;
            return GetResult(await _userService.UpdateAsync(userDto));
        }

        [HttpDelete("{id}")]
        public async Task<Response> Create([FromRoute] Guid id)
        {
            return GetResult(await _userService.DeleteAsync(id));
        }
    }
}
