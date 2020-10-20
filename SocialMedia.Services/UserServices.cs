using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateUser(UserCreate model)
        {
            var entity = new User()
            {
                UserID = _userId,
                Name = model.Name,
                Email = model.Email,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.User.Add(entity);
                var testing = ctx.SaveChanges();
                return true;
            }
        }
        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.User.Where(e => e.UserID == _userId).Select
                    (e => new UserListItem
                    {
                        Name = e.Name
                        
                    }
                    ); 
                return query.ToArray();
            }

        }
        public UserDetail GetUserByName(string id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.User.Single(e => e.Name == id && e.UserID == _userId);
                return new UserDetail
                {
                    Name = entity.Name,
                    Email = entity.Email,
                };
            }
        }
        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.User.Single(e => e.UserID == _userId);

                entity.Name = model.Name;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteUser(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.User.Single(e => e.Name == name && e.UserID == _userId);

                ctx.User.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
