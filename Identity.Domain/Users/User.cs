using Identity.Domain.Companies;
using Identity.Domain.Utils.Common;
using Identity.Domain.Utils.Hash;
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

        protected User() {
            _companiesUsers = new List<CompanyUser>();
        }
    }
}
