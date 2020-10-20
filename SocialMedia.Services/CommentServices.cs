using Microsoft.TeamFoundation.Discussion.Client;
using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Comment = SocialMedia.Data.Comment;

namespace SocialMedia.Services
{
    public class CommentService
    {
        //private readonly int _commentID;
        //public CommentService(int commentID)
        //{
        //    _commentID = commentID;
        //}
        public bool CreateComment(CommentCreate model)
        {
            var entity =
            new Comments()
            {
                //UserID = model.UserID,
                PostID = model.PostID,
                Text = model.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.ID == id)
                        .Select(
                            e =>
                                new CommentListItem
                                {

                                    ID = e.ID,
                                    Text = e.Text,
                                    CommentPost = ctx.Posts.ElementAt(id)
                                }
                                ) ;

                return query.ToArray();
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments.Single(e => e.ID == model.ID);

                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments.Single(e =>e.ID == id);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
