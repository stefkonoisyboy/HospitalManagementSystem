using HospitalManagementSystem.Shared.BlogCategories;
using HospitalManagementSystem.Shared.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.BlogPosts
{
    public class BlogPostDetailsViewModel : AllLatestBlogPostsViewModel
    {
        public BlogPostDetailsViewModel()
        {
            this.Tags = new List<AllTagsForDropDownViewModel>();
        }

        public string Content { get; set; }

        public IEnumerable<AllTagsForDropDownViewModel> Tags { get; set; }
    }
}
