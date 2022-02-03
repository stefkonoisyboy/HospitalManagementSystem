using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class BlogCategory
    {
        public BlogCategory()
        {
            this.BlogPosts = new HashSet<BlogPost>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}
