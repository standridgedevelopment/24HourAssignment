﻿using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class PostDetail
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public virtual User Author { get; set; }
    }
}
