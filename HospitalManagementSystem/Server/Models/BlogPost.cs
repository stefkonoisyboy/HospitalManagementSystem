using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class BlogPost
    {
        public BlogPost()
        {
            this.Tags = new HashSet<BlogPostTag>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string RemoteImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public int BlogCategoryId { get; set; }

        public virtual BlogCategory BlogCategory { get; set; }

        public virtual ICollection<BlogPostTag> Tags { get; set; }
    }
}
