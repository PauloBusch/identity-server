﻿using Identity.Domain._Common.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [Authorize]
    [ApiController]
    public class IdentityControllerBase : ControllerBase
    {
        protected Result GetResult(Result result) { 
            Response.StatusCode = (int)result.Status;
            return result;
        }

        protected Result<T> GetResult<T>(Result<T> result) where T : class
        {
            Response.StatusCode = (int) result.Status;
            return result;
        }

        protected Result<T> GetResult<T>(T data) where T : class 
        { 
            return new Result<T>(data);
        }
    }
}
