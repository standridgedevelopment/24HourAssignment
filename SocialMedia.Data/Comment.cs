﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Comment
    {
        [ForeignKey(nameof(UserID))]
        public Guid UserID;
        [ForeignKey(nameof(PostID))]
        public int PostID;
        

        [Key]
        public int CommentID { get; set; }
        [Required]
        public string Text { get; set; }
        public virtual User Author { get; set; }
        public virtual Post CommentPost { get; set; }
    }
}
