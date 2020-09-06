using Identity.Domain.Clients;
using Identity.Domain.Utils.Common;
using System.Collections.Generic;

namespace Identity.Domain.Apps
{
    public class Client : EntityBase
    {
        public string Name { get; private set; }
        public string Url { get; private set; }
        public IReadOnlyCollection<ClientCompany> ClientsCompanies => _clientsCompanies.AsReadOnly();

        private List<ClientCompany> _clientsCompanies;

        protected Client() {
            _clientsCompanies = new List<ClientCompany>();
        }
    }
}
