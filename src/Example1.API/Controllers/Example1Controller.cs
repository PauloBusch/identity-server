using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace Example1.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class Example1Controller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new 
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55)
            })
            .ToArray();
        }
    }
}
