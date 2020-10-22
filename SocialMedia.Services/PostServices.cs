using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class PostServices
    {
        private readonly Guid _userId;

        public PostServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    UserID = _userId,
                    Title = model.Title,
                    Text = model.Text
                    //Author = model.Author
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                var testing = ctx.SaveChanges();
                return true;
            }
        }

        public IEnumerable<PostListItem> GetPosts(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.ID == id)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    ID = e.ID,
                                    Title = e.Title,
                                    Author = e.Author
                                }
                        );

                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.ID == id);
                return
                    new PostDetail
                    {
                        ID = entity.ID,
                        Title = entity.Title,
                        Text = entity.Text,
                        Author = entity.Author
                    };
            }
        }
    }
}
