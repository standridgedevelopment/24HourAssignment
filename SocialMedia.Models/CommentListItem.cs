using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class CommentListItem
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public virtual Post CommentPost { get; set; }
        //public virtual User Author { get; set; }

    }
}
