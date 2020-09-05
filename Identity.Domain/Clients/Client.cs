using Identity.Domain.Companies;
using Identity.Domain.Utils.Common;
using System;
using System.Collections.Generic;

namespace Identity.Domain.Apps
{
    public class Client : EntityBase
    {
        public string Name { get; private set; }
        public string Url { get; private set; }

        public Client(
            Guid? id,
            string name,
            string url
        ) : base(id ?? Guid.NewGuid())
        {
            Name = name;
            Url = url;
        }
    }
}
