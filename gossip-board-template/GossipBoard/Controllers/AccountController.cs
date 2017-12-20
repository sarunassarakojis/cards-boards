using System.Threading.Tasks;
using GossipBoard.Models.Client;
using GossipBoard.Services;
using GossipBoard.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GossipBoard.Controllers
{
    [Authorize]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return Ok(false);
            }

            var user = new User
            {
                Email = model.Email,
                Username = model.UserName
            };

            var applicationUser = new ApplicationUser
            {
                UserName = model.UserName,
                User = user
            };

            var result = await _userManager.CreateAsync(applicationUser, model.Password);
            return Ok(result.Succeeded);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            await Logout();
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return Ok(true);
            }
            if (result.IsLockedOut)
            {
                return Ok(false);
            }

            return Ok(false);
        }

        [HttpPost("logout")]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            if (_signInManager.IsSignedIn(User))
            {
                await _signInManager.SignOutAsync();
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult IsSignedIn()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return Ok(true);
            }

            return Ok(false);

        }
    }
}
