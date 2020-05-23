using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TwitterClone.Models
{
    public class Person
    {
        public Person()
        {
            Tweet = new HashSet<Tweet>();
        }
        public DateTime Joined
        {
            get
            {
                return joined.HasValue
                   ? joined.Value
                   : DateTime.Now;
            }

            set { this.joined = value; }
        }

        [DisplayName("User ID")]
        public string UserId { get; set; }
        public string Password { get; set; }
        [DisplayName("Full Name")]
        public string Fullname { get; set; }
        public string Email { get; set; }
      
        private DateTime? joined { get; set; }
        [DefaultValue(1)]
        public int Active { get; set; }

        public ICollection<Tweet> Tweet { get; set; }
    }
}