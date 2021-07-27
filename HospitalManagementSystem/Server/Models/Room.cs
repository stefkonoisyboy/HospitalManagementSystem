using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class Room
    {
        public Room()
        {
            this.Beds = new HashSet<Bed>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int FloorId { get; set; }

        public virtual Floor Floor { get; set; }

        public virtual ICollection<Bed> Beds { get; set; }
    }
}
