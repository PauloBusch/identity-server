using Identity.Domain.Users;
using Identity.Domain.Utils.Common;
using System;

namespace Identity.Domain.Companies
{
    public class CompanyUser : EntityBase
    {
        public Guid CompanyId { get; private set; }
        public Guid UserId { get; private set; }

        public Company Company { get; private set; }
        public User User { get; private set; }
        
        public CompanyUser(
            Guid? id,
            Guid companyId,
            Guid userId
        ) : base(id ?? Guid.NewGuid())
        {
            CompanyId = companyId;
            UserId = userId;
        }
    }
}
