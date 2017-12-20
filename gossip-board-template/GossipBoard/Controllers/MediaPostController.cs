using System;
using System.Threading.Tasks;
using GossipBoard.Models.Client;
using GossipBoard.Models.Post.Media;
using GossipBoard.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GossipBoard.Controllers
{
    [Route("api/mediaPost")]
    public class MediaPostController : Controller
    {
        private readonly IMediaPostService _service;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;

        public MediaPostController(IMediaPostService service, UserManager<ApplicationUser> userManager,
            IUserService userService)
        {
            _service = service;
            _userManager = userManager;
            _userService = userService;
        }
        [HttpGet]
        [Produces(typeof(MediaPost[]))]
        public async Task<IActionResult> Get([FromQuery]int offset = 0, [FromQuery]int limit = 10)
        {
            var mediaPosts = await _service.GetAllMediaPosts(offset, limit);
            return Ok(mediaPosts);
        }

        [HttpGet("{id}")]
        [Produces(typeof(MediaPost))]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var result = await _service.GetMediaPostById(id);

            if (result == null)
            {
                return NotFound("We couldn't find media post with this ID. Please refresh and try again.");
            }
            return Ok(result);
        }

        [HttpPost]
        [Produces(typeof(MediaPost))]
        public async Task<IActionResult> Post([FromBody]MediaPost value)
        {
            var applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            if (applicationUser == null) return Unauthorized();
            var user = _userService.GetUserById(applicationUser.Id);
            value.PostAuthor = user;
            value.CreationTime = DateTime.Now;
            var mediaPost = await _service.Create(value);
            return Ok(mediaPost);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] MediaPost mediaPost)
        {
            var updatedMediaPost = await _service.Update(mediaPost);

            return Ok(updatedMediaPost);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.Delete(id);

            if (result == false)
            {
                return NotFound("We couldn't delete media post with this ID. Please refresh and try again.");
            }
            return Ok();
        }
    }
}
