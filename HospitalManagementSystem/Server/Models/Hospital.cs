using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class Hospital
    {
        public Hospital()
        {
            this.Users = new HashSet<ApplicationUser>();
            this.Floors = new HashSet<Floor>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public virtual ICollection<Floor> Floors { get; set; }
    }
}
