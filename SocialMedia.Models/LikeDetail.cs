using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class LikeDetail
    {
        public virtual Post LikedPost { get; set; }
    }
}
