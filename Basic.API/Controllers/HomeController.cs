using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace Basic.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() { 
            return Ok("Home page");    
        }

        [Authorize]
        public ActionResult Secret()
        {
            return Ok("Secret");
        }

        public ActionResult Authenticate()
        {
            var grandmaClaims = new List<Claim> { 
                new Claim(ClaimTypes.Name, "Paulo"), 
                new Claim(ClaimTypes.Email, "paulo@email.com"), 
                new Claim("Basic.Claim", "Claim value")
            };

            var licenseClaims = new List<Claim> {
                new Claim(ClaimTypes.Name, "Paulo Ricardo Busch"),
                new Claim("Basic.License.Claim", "License claim value")
            };
            var grandmaIdenity = new ClaimsIdentity(grandmaClaims, "Grandma Identity");
            var licenseIdenity = new ClaimsIdentity(licenseClaims, "License");
            
            var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdenity, licenseIdenity });

            HttpContext.SignInAsync(userPrincipal);
            return RedirectToAction("Index");
        }
    }
}
