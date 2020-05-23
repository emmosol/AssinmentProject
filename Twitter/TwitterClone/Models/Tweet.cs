using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class Tweet
    {
        public int TweetId { get; set; }
        [DisplayName("User")]
        public string UserId { get; set; }
        public string Message { get; set; }
        [DisplayName("Posted on")]
        public DateTime Created { get; set; }

        public Person User { get; set; }
    }
}