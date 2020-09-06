using AutoMapper;
using Identity.Domain.Clients.Repositories;
using Identity.Domain.Clients.Services;
using Identity.Domain.Companies;
using Identity.Domain.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Service.Clients
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientService(
            IClientRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<IEnumerable<Company>> GetCompaniesAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserHasAccessAsync(Guid userId, Guid companyId)
        {
            throw new NotImplementedException();
        }
    }
}
