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
        public IHttpActionResult Get()
        {
            PostServices postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);
        }

        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
        }

        private PostServices CreatePostService()
        {
            var postId = int.Parse(User.Identity.Name);
            var postService = new PostServices(postId);
            return postService;
        }

        public IHttpActionResult Get(int id)
        {
            PostServices postService = CreatePostService();
            var post = postService.GetPostById(id);
            return Ok(post);
        }

        public IHttpActionResult Put(PostEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.UpdatePost(note))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreatePostService();

            if (!service.DeletePost(id))
                return InternalServerError();

            return Ok();
        }
    }
}
