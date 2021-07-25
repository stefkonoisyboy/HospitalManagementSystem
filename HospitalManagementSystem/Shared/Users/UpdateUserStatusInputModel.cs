using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Users
{
    public class UpdateUserStatusInputModel
    {
        public string Username { get; set; }

        public bool Status { get; set; }
    }
}
