using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class LikeListItem
    {
        public virtual User Liker { get; set; }
        public string User;
    }
}
