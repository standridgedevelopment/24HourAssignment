//using Microsoft.AspNet.Identity;
//using SocialMedia.Models;
//using SocialMedia.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;

//namespace SocialMedia.WebAPI.Controllers
//{
//    public class LikeController : ApiController
//    {
//        //[HttpGet]
//        //public IHttpActionResult Get(string id)
//        //{
//        //    LikeService likeService = CreateLikeService();
//        //    var user = likeService.GetLikes(id);
//        //    return Ok(user);
//        //}
//        [HttpGet]
//        public IHttpActionResult Get(int id)
//        {
//            LikeService likeService = CreateLikeService();
//            var user = likeService.GetLikesByPost(id);
//            return Ok(user);
//        }
//        public IHttpActionResult Post(LikeCreate like)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var service = CreateLikeService();

//            if (!service.CreateLike(like))
//                return InternalServerError();

//            return Ok();
//        }
//        public IHttpActionResult Put(LikeEdit like)
//        {
//            if (!ModelState.IsValid) return BadRequest(ModelState);

//            var service = CreateLikeService();

//            if (!service.UpdateLike(like)) return InternalServerError();

//            return Ok();
//        }
//        public IHttpActionResult Delete(string id)
//        {
//            var service = CreateLikeService();

//            if (!service.DeleteLike(id)) return InternalServerError();

//            return Ok();
//        }
//        private LikeService CreateLikeService()
//        {
//            var userID = Guid.Parse(User.Identity.GetUserId());
//            var userService = new LikeService(userID);
//            return userService;
//        }
//    }
//}
