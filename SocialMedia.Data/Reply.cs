using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Reply : Comments
    {
        //[Required]
        //public int CommentID { get; set; }
        //[ForeignKey(nameof(CommentID))]
        //public virtual Post ReplyComment { get; set; }
    }
}
