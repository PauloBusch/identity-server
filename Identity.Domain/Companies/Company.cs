using Identity.Domain.Users;
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
        public IReadOnlyCollection<User> Users => _users.AsReadOnly();

        private List<User> _users;

        public Company(
            Guid? id,
            string name,
            string federalRegistration
        ) : base(id ?? Guid.NewGuid())
        {
            _users = new List<User>();
            Name = name;
            FederalRegistration = federalRegistration;
            Active = true;
        }
    }
}
