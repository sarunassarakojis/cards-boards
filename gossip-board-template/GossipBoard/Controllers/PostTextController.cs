using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GossipBoard.Models;
using GossipBoard.Models.Client;
using GossipBoard.Models.Post.Text;
using GossipBoard.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GossipBoard.Controllers
{
    [Route("api/textPost")]
    public class PostTextController : Controller
    {
        private readonly ITextPostService _service;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;

        public PostTextController(ITextPostService service, UserManager<ApplicationUser> userManager,
            IUserService userService)
        {
            _service = service;
            _userManager = userManager;
            _userService = userService;
        }
        [HttpGet]
        [Produces(typeof(TextPost[]))]
        public async Task<IActionResult> Get([FromQuery]int offset = 0, [FromQuery]int limit = 10)
        {
            var textPosts = await _service.GetAllTextPosts(offset, limit);
            return Ok(textPosts);
        }

        [HttpGet("{id}")]
        [Produces(typeof(TextPost))]
        public async Task<IActionResult> Get([FromRoute]int id)
        {
            var result = await _service.GetTextPostById(id);

            if (result == null)
            {
                return NotFound("We couldn't find text post with this ID. Please refresh and try again.");
            }
            return Ok(result);
        }

        [HttpPost]
        [Produces(typeof(TextPost))]
        public async Task<IActionResult> Post([FromBody]TextPost value)
        {
            var applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            if (applicationUser == null) return Unauthorized();
            var user = _userService.GetUserById(applicationUser.Id);
            value.PostAuthor = user;
            value.CreationTime = DateTime.Now;
            var postText = await _service.Create(value);
            return Ok(postText);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]TextPost textPost)
        {
            var updatedTextPost = await _service.Update(textPost);

            return Ok(updatedTextPost);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var result = await _service.Delete(id);

            if (result == false)
            {
                return NotFound("We couldn't delete text post with this ID. Please refresh and try again.");
            }
            return Ok();
        }

        [HttpPost("like")]
        public async Task<IActionResult> LikeTextPost([FromBody] TextPost textPost)
        {
            var applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            if (applicationUser == null) return Unauthorized();
            var user = _userService.GetUserById(applicationUser.Id);
            var textPostLike = new TextPostLike
            {
                LikeOwner = user
            };
            textPost.Likes.Add(textPostLike);
            await _service.Like(textPostLike);
            var likedTextPost = await _service.Update(textPost);
            return Ok(likedTextPost);
        }
    }
}
