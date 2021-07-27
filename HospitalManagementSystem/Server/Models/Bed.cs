using HospitalManagementSystem.Server.Models.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class Bed
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public BedStatus Status { get; set; }

        public BedType Type { get; set; }

        public decimal PricePerDay { get; set; }

        public string RemoteImageUrl { get; set; }

        public int RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
