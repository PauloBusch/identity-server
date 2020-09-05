using Identity.Domain.Companies.Repositories;
using Identity.Domain.Users;
using Identity.Domain.Utils.Common;
using Identity.Domain.Utils.interfaces;
using System;
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

        public async Task<User> GetUsers(Guid id)
        {
            return await _companyRepository.GetUsers(id);
        }
    }
}
