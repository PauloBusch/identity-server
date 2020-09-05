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

        public Company(
            Guid? id,
            string name,
            string federalRegistration
        ) : base(id ?? Guid.NewGuid())
        {
            Name = name;
            FederalRegistration = federalRegistration;
            Active = true;
        }
    }
}
