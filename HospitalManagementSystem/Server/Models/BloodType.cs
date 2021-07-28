using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class BloodType
    {
        public BloodType()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
