using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class Following
    {
        public string user_id { get; set; }
        public string following_id { get; set; }
        public Person User { get; set; }
        public Person Follower { get; set; }
    }
}