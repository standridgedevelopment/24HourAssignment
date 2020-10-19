using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Post
    {
        [ForeignKey(nameof(ID))]
        public Guid ID;
        //public virtual User User { get; set; }
        
        
        public int Id;
        public string Title;
        public string Text;
        public User Author;

    }
}
