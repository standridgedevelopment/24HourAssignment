using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class LikeService
    {
        private readonly Guid _userId;

        public LikeService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLike(LikeCreate model)
        {
            var entity = new Like()
            {
                Liker = model.Liker,
                Name = model.Name,
                LikedPost = model.LikedPost,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                var testing = ctx.SaveChanges();
                return true;
            }
        }

        //See all likes posts by Name
        public IEnumerable<LikeDetail> GetLikes(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Likes.Where(e => e.Name == name).Select
                    (e => new LikeDetail
                    {
                        LikedPost = e.LikedPost
                    }
                    );
                return query.ToArray();
            }

        }
        //See all likes by Post
        public IEnumerable<LikeListItem> GetLikesByPost(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Likes.Where(e => e.PostID == id).Select
                    (e => new LikeListItem
                    {
                        User = e.Liker.Name
                    }
                    );
                return query.ToArray();
            }

        }
        public bool UpdateLike(LikeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Likes.Single();

                entity.PostID = model.PostID;
               

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLike(string name)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Likes.Single(e => e.Name == name);

                ctx.Likes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
