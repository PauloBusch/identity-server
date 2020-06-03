using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Dtos
{
    public class VerifyEmailDto
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }
}
