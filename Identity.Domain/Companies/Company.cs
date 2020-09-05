using Identity.Domain.Clients;
using Identity.Domain.Utils.Common;
using System;
using System.Collections.Generic;

namespace Identity.Domain.Companies
{
    public class Company : EntityBase
    {
        public string Name { get; private set; }
        public string FederalRegistration { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<ClientCompany> ClientsCompanies => _clientsCompanies.AsReadOnly();
        public IReadOnlyCollection<CompanyUser> CompaniesUsers => _companiesUsers.AsReadOnly(); 

        private List<ClientCompany> _clientsCompanies;
        private List<CompanyUser> _companiesUsers;

        public Company(
            Guid? id,
            string name,
            string federalRegistration
        ) : base(id ?? Guid.NewGuid())
        {
            _companiesUsers = new List<CompanyUser>();
            _clientsCompanies = new List<ClientCompany>();
            Name = name;
            FederalRegistration = federalRegistration;
            Active = true;
        }
    }
}
