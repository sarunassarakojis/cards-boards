using System;
using System.Threading.Tasks;
using GossipBoard.Models.Client;
using GossipBoard.Models.Post.Poll;
using GossipBoard.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GossipBoard.Controllers
{
    [Route("api/pollPost")]
    public class PollPostController : Controller
    {
        private readonly IPollPostService _service;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;

        public PollPostController(IPollPostService service, UserManager<ApplicationUser> userManager,
            IUserService userService)
        {
            _service = service;
            _userManager = userManager;
            _userService = userService;
        }

        [HttpGet]
        [Produces(typeof(PollPost[]))]
        public async Task<IActionResult> Get([FromQuery] int offset = 0, [FromQuery] int limit = 10)
        {
            var pollPosts = await _service.GetAllPollPosts(offset, limit);
            return Ok(pollPosts);
        }

        [HttpGet("{id}")]
        [Produces(typeof(PollPost))]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var result = await _service.GetPollPostById(id);

            if (result == null)
            {
                return NotFound("We couldn't find media post with this ID. Please refresh and try again.");
            }
            return Ok(result);
        }

        [HttpPost]
        [Produces(typeof(int))]
        public async Task<IActionResult> Post([FromBody] PollPost value)
        {
            var applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            if (applicationUser == null) return Unauthorized();
            var user = _userService.GetUserById(applicationUser.Id);
            value.PostAuthor = user;
            value.CreationTime = DateTime.Now;
            var pollPost = await _service.Create(value);
            return Ok(pollPost);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PollPost pollPost)
        {
            var updatedPollPost = await _service.Update(pollPost);

            return Ok(updatedPollPost);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _service.Delete(id);

            if (result == false)
            {
                return NotFound("Poll post with an Id of: " + id + " was not found");
            }
            return Ok();
        }
    }
}