using Identity.API.Data;
using Identity.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Basic.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager
        ) {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ActionResult Index() { 
            return Ok("Home page");    
        }

        [Authorize]
        public ActionResult Secret()
        {
            return Ok("Secret");
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDto data)
        {
            var user = await _userManager.FindByNameAsync(data.UserName);
            if (user != null) { 
                var signInResult = await _signInManager.PasswordSignInAsync(user, data.Password, false, false);
                if (signInResult.Succeeded) {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Register([FromBody] CreateUserDto data)
        {
            var user = new IdentityUser { 
                UserName = data.UserName,
                Email = ""
            };
            var result = await _userManager.CreateAsync(user, data.Password);
            if (result.Succeeded) {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var link = Url.Action(nameof(VerifyEmail), "Home", new { userId = user.Id, code });
                _userManager.ConfirmEmailAsync();
                return RedirectToAction("Email Verification");
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> VerifyEmail([FromBody] VerifyEmailDto data) {
            return RedirectToAction("Index");    
        }
    }
}
