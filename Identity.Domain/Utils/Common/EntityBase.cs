using System;

namespace Identity.Domain.Utils.Common
{
    public class EntityBase
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
    }
}
