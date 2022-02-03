using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.BlogPosts
{
    public class AllLatestBlogPostsViewModel
    {
        public int Id { get; set; }

        public string RemoteImageUrl { get; set; }

        public string Title { get; set; }

        public string CreatorRemoteProfileImageUrl { get; set; }

        public string CreatorFullName { get; set; }

        public string BlogCategoryName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string DifferenceBetweenNowAndCreatedOn => this.DifferenceInSpecialFormat();

        private string DifferenceInSpecialFormat()
        {
            string result = string.Empty;

            TimeSpan diff = DateTime.UtcNow.Subtract(this.CreatedOn);
            int seconds = (int)diff.TotalSeconds;
            int minutes = seconds / 60;
            int hours = minutes / 60;
            int days = hours / 24;
            int weeks = days / 7;
            int years = weeks / 52;

            if (seconds == 1)
            {
                result = "1 second ago";
            }
            else if (seconds > 1 && seconds <= 59)
            {
                result = $"{seconds} seconds ago";
            }
            else if (minutes == 1)
            {
                result = "1 minute ago";
            }
            else if (minutes > 1 && minutes <= 59)
            {
                result = $"{minutes} minutes ago";
            }
            else if (hours == 1)
            {
                result = "1 hour ago";
            }
            else if (hours > 1 && hours <= 23)
            {
                result = $"{hours} hours ago";
            }
            else if (days == 1)
            {
                result = "1 day ago";
            }
            else if (days > 1 && days <= 6)
            {
                result = $"{days} days ago";
            }
            else if (weeks == 1)
            {
                result = "1 week ago";
            }
            else if (weeks > 1 && weeks <= 51)
            {
                result = $"{weeks} weeks ago";
            }
            else if (years == 1)
            {
                result = "1 year ago";
            }
            else if (years > 1)
            {
                result = $"{years} years ago";
            }

            return result;
        }
    }
}
