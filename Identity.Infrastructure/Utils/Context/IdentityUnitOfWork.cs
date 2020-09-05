using Identity.Domain.Clients.Repositories;
using Identity.Domain.Companies.Repositories;
using Identity.Domain.Users.Repositories;
using Identity.Domain.Utils.Interfaces;
using Identity.Domain.Utils.Responses;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Utils.Context
{
    public class UnitOfWork : IIdentityUnitOfWork
    {
        public IUserRepository Users { get; private set; }

        public ICompanyRepository Companies { get; private set; }

        public IClientRepository Clients { get; private set; }

        private readonly IdentityContext _context;

        public UnitOfWork(
            IdentityContext context,
            IUserRepository userRepository,
            ICompanyRepository companyRepository,
            IClientRepository clientRepository
        )
        {
            _context = context;
            Companies = companyRepository;
            Clients = clientRepository;
            Users = userRepository;
        }

        public async Task<Response> CommitAsync()
        {
            var rows = await _context.SaveChangesAsync();
            return new Response(rows);
        }
    }
}
