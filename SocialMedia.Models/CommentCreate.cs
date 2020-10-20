﻿using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class CommentCreate
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public int PostID { get; set; }
        [MaxLength(10000)]
        public string Text { get; set; }

    }
}
