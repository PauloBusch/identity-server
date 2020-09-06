using AutoMapper;
using Identity.Domain.Companies.Repositories;
using Identity.Domain.Companies.Services;
using Identity.Domain.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Service.Companies
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;
        private readonly IMapper _mapper;

        public CompanyService(
            ICompanyRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<IEnumerable<UserResponseDto>> GetUsersAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
