using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Models
{
    public class Likes
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
