using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    class CommentCreate
    {
        [MaxLength(10000)]
        public string Text { get; set; }
    }
}
