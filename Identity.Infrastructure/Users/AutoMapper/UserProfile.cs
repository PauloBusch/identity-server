using AutoMapper;
using Identity.Domain.Users;
using Identity.Domain.Users.Dtos;
using Identity.Domain.Utils.Hash;
using System;

namespace Identity.Infrastructure.Users.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequestDto, User>()
                .ForMember(d => d.Id, m => m.MapFrom(s => s.Id ?? Guid.NewGuid()))
                .ForMember(d => d.PasswordHash, m => m.MapFrom(s => MD5Crypto.Encode(s.Password)));
            CreateMap<User, UserResponseDto>();
        }
    }
}
