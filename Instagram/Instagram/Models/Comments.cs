﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Models
{
    public class Comments
    {
        public Guid ComId { get; set; }
        public Guid PostId { get; set; }
        public Guid FromId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public List<string> ComHashtags { get; set; }
    }
}
