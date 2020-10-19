using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Like
    {
        [ForeignKey(nameof(UserID))]
        public Guid UserID;
        [ForeignKey(nameof(PostID))]
        public int PostID;
        public virtual Post LikedPost { get; set; }
        public virtual User Liker { get; set; }
    }
}
