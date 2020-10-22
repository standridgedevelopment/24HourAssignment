using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialMedia.WebAPI.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            PostServices postService = CreatePostService();
            var posts = postService.GetPosts(id);
            return Ok(posts);
        }

        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PostServices postService = CreatePostService();

            if (!postService.CreatePost(post))
                return InternalServerError();

            return Ok();
        }

        private PostServices CreatePostService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var userService = new PostServices(userID);
            return userService;
        }

    }
}
