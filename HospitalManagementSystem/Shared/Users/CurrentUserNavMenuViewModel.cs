using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Users
{
    public class CurrentUserNavMenuViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfileImageUrl { get; set; }

        public bool IsActive { get; set; }
    }
}
