using Identity.Domain.Utils.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Identity.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityControllerBase : ControllerBase
    {
        public Response GetResult(Response response){ 
            Response.StatusCode = (int)response.Status;
            return response;
        }

        public Response<T> GetResult<T>(T data) where T : class
        {
            return new Response<T>(data);
        }
    }
}
