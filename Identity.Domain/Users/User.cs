using Identity.Domain.Companies;
using Identity.Domain.Utils.Common;
using System;
using System.Collections.Generic;

namespace Identity.Domain.Users
{
    public class User : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public IReadOnlyCollection<CompanyUser> CompaniesUsers => _companiesUsers.AsReadOnly();

        private List<CompanyUser> _companiesUsers;

        public User(
            Guid? id,
            string name,
            string password
        ) : base(id ?? Guid.NewGuid()) { 
            Name = name;
            PasswordHash = password;
        }
    }
}
