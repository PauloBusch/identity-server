﻿using AutoMapper;
using Identity.Domain.Users;
using Identity.Domain.Users.Dtos;
using Identity.Domain.Users.Repositories;
using Identity.Domain.Users.Services;
using Identity.Domain.Utils.Enums;
using Identity.Domain.Utils.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository repository,
            IMapper mapper
        ) {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response> CreateAsync(UserRequestDto userDto)
        {
            var exist = await _repository.ExistByEmailAsync(userDto.Email);
            if (exist) return new Response(EStatus.Conflict, "Já existe um usuário com este email");
            var user = _mapper.Map<User>(userDto);
            await _repository.CreateAsync(user);
            return new Response();
        }

        public async Task<Response> DeleteAsync(Guid id)
        {
            var user = await _repository.GetAsync(id);
            await _repository.DeleteAsync(user);
            return new Response();
        }

        public async Task<UserResponseDto> GetAsync(Guid id)
        {
            var user = await _repository.GetAsync(id);
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.ProjectTo<UserResponseDto>(users.AsQueryable());
        }

        public async Task<Response> UpdateAsync(UserRequestDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _repository.UpdateAsync(user);
            return new Response();
        }
    }
}
