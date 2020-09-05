using Identity.Domain.Companies.Repositories;
using Identity.Domain.Users;
using Identity.Domain.Utils.Common;
using Identity.Domain.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Companies.Services
{
    public class CompanyService : ServiceBase<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(IUnitOfWork uow) : base(uow, uow.Companies)
        {
            _companyRepository = uow.Companies;
        }

        public async Task<IEnumerable<User>> GetUsersAsync(Guid id)
        {
            return await _companyRepository.GetUsersAsync(id);
        }
    }
}
