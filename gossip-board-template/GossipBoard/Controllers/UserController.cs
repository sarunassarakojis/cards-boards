using System.Threading.Tasks;
using GossipBoard.Models.Client;
using GossipBoard.Services;
using GossipBoard.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GossipBoard.Controllers
{
    [Authorize]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            if (applicationUser == null)
            {
                return Unauthorized();
            }

            var user = _userService.GetUserById(applicationUser.Id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        /*[HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetUsername([FromQuery]int id)
        {
            var applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            if (applicationUser == null)
            {
                return Unauthorized();
            }

            var user = _userService.GetUserById(applicationUser.Id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.Username);
        }*/

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return Ok(false);
            }
            var applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            if (applicationUser == null) return Ok(false);
            var result = await _userManager.ChangePasswordAsync(applicationUser, model.OldPassword, model.Password);
            if (!result.Succeeded) return Ok(false);
            await _signInManager.SignInAsync(applicationUser, false);
            return Ok(true);
        }
    }
}
