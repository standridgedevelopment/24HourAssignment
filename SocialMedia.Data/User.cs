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
        [Required]
        public Guid ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
