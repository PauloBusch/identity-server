using System;

namespace Identity.Domain.Utils.Common
{
    public class EntityBase
    {
        public Guid Id { get; private set; }

        public EntityBase(Guid id) { 
            Id = id;    
        }
    }
}
