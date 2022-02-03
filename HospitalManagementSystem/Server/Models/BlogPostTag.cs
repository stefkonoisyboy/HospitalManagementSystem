using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class BlogPostTag
    {
        public int Id { get; set; }

        public int BlogPostId { get; set; }

        public virtual BlogPost BlogPost { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
