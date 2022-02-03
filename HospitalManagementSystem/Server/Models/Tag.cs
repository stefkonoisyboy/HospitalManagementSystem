using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class Tag
    {
        public Tag()
        {
            this.BlogPosts = new HashSet<BlogPostTag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BlogPostTag> BlogPosts { get; set; }
    }
}
