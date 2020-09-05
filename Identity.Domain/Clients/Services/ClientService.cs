using Identity.Domain.Apps;
using Identity.Domain.Clients.Repositories;
using Identity.Domain.Companies;
using Identity.Domain.Users;
using Identity.Domain.Utils.Common;
using Identity.Domain.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Clients.Services
{
    public class ClientService : ServiceBase<Client>, IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IIdentityUnitOfWork uow) : base(uow, uow.Clients)
        {
            _clientRepository = uow.Clients;
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync(Guid id)
        {
            return await _clientRepository.GetCompaniesAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync(Guid id)
        {
            return await _clientRepository.GetUsersAsync(id);
        }

        public async Task<bool> UserHasAccessAsync(Guid userId, Guid companyId)
        {
            return await _clientRepository.UserHasAccessAsync(userId, companyId);
        }
    }
}
