﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    class Reply : Comment
    {
        public virtual Post ReplyComment { get; set; }
    }
}
