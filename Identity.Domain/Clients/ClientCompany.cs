using Identity.Domain.Apps;
using Identity.Domain.Companies;
using Identity.Domain.Utils.Common;
using System;

namespace Identity.Domain.Clients
{
    public class ClientCompany : EntityBase
    {
        public Guid ClientId { get; private set; }
        public Guid CompanyId { get; private set; }

        public Client Client { get; private set; }
        public Company Company { get; private set; }

        protected ClientCompany() { }
    }
}
