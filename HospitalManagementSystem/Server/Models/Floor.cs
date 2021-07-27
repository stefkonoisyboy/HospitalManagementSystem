using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class Floor
    {
        public Floor()
        {
            this.Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int HospitalId { get; set; }

        public virtual Hospital Hospital { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
