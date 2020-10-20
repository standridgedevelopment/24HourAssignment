using Microsoft.AspNet.Identity;
using SocialMedia.Data;
using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialMedia.WebAPI.Controllers
{
    public class CommentController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            CommentService commentService = CreateCommentService();
            var comment = commentService.GetComment(id);
            return Ok(comment);
        }

        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.UpdateComment(comment)) return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCommentService();
            if (!service.DeleteComment(id)) return InternalServerError();

            return Ok();
        }

        private CommentService CreateCommentService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var postService = new CommentService();
            return postService;
        }


    }
}
