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
        private readonly int _postId;

        public PostServices(int postId)
        {
            _postId = postId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    PostId = _postId,
                    Title = model.Title,
                    Text = model.Text,
                    Author = model.Author,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.PostId == _postId)
                        .Select(
                            e =>
                                new PostListItem
                                {
                                    PostId = e.PostId,
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
                        .Single(e => e.PostId == id && e.PostId == _postId);
                return
                    new PostDetail
                    {
                        PostId = entity.PostId,
                        Title = entity.Title,
                        Text = entity.Text,
                        Author = entity.Author
                    };
            }
        }

        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == model.PostId && e.PostId == _postId);

                entity.Title = model.Title;
                entity.Text = model.Text;
                entity.Author = model.Author;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == postId && e.PostId == _postId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
