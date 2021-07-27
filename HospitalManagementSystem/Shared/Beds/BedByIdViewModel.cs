using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Beds
{
    public class BedByIdViewModel : AllBedsByFloorIdViewModel
    {
        public decimal PricePerDay { get; set; }

        public string RemoteImageUrl { get; set; }
    }
}
