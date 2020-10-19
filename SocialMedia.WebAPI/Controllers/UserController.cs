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
    public class UserController : ApiController
    {
        public IHttpActionResult Get()
        {
            UserService noteService = CreateUserService();
            var notes = noteService.GetUsers();
            return Ok(notes);
        }
        //public IHttpActionResult Get(int id)
        //{
        //    NoteService noteService = CreateNoteService();
        //    var note = noteService.GetNoteById(id);
        //    return Ok(note);
        //}
        public IHttpActionResult Post(UserCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateUserService();

            if (!service.CreateUser(note))
                return InternalServerError();

            return Ok();
        }
        private UserService CreateUserService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var userService = new UserService(userID);
            return userService;
        }
    }
}
