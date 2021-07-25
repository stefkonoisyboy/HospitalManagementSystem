using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Users
{
    public class CurrentUserViewModel
    {
        public string Role { get; set; }

        public string FullName { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string ProfileImageUrl { get; set; }
    }
}
