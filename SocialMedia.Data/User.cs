using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class User
    {
        
        public int ID { get; set; }
        [Required]
        public Guid UID { get; set; }
        [Key]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        //public virtual List<Post> Posts { get; set; } = new List<Post>();
    }
}
