<<<<<<< HEAD
﻿using Microsoft.AspNet.Identity;
using SocialMedia.Data;
using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
>>>>>>> development
using System.Web.Http;

namespace SocialMedia.WebAPI.Controllers
{
    public class CommentController : ApiController
    {
<<<<<<< HEAD
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comment = commentService.GetComment();
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

        public IHttpActionResult Delete(string id)
        {
            var service = CreateCommentService();

            if (!service.DeleteComment(id)) return InternalServerError();

            return Ok();
        }

        private CommentService CreateCommentService()
        {
            var commentID = int.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(commentID);
            return commentService;
        }


    }
}
=======
    }
}
>>>>>>> development
