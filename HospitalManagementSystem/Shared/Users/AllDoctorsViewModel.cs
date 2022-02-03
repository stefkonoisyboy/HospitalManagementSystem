using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Users
{
    public class AllDoctorsViewModel
    {
        public string Id { get; set; }

        public string Department { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public string ProfileImageRemoteUrl { get; set; }
    }
}
