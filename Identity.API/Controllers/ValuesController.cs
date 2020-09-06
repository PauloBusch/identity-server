using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{

    public class ValuesController : IdentityControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Identity is running";
        }
    }
}
