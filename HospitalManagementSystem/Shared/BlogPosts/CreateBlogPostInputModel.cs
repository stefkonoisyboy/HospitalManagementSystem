using HospitalManagementSystem.Shared.BlogCategories;
using HospitalManagementSystem.Shared.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.BlogPosts
{
    public class CreateBlogPostInputModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(250)]
        public string Content { get; set; }

        public string RemoteImageUrl { get; set; }

        public string CreatorId { get; set; }

        [Required]
        public int BlogCategoryId { get; set; }

        public IEnumerable<AllBlogCategoriesForDropDownViewModel> BlogCategories { get; set; }

        public IEnumerable<int> TagIds { get; set; }

        public IEnumerable<AllTagsForDropDownViewModel> Tags { get; set; }
    }
}
