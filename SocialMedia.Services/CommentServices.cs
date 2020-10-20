using Microsoft.TeamFoundation.Discussion.Client;
using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comment = SocialMedia.Data.Comment;

namespace SocialMedia.Services
{
    public class CommentService
    {
        private readonly int _commentID;
        public CommentService(int commentID)
        {
            _commentID = commentID;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
            new Comment()
            {
                Text = model.Text,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.CommentID == _commentID)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentID = e.CommentID,
                                    Text = e.Text,
                                }
                        );

                return query.ToArray();
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments.Single(e => e.CommentID == _commentID);

                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(string comment)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments.Single(e => e.Text == comment && e.CommentID == _commentID);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
