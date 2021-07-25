using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Treatments
{
    public class AllTreatmentsByUserIdViewModel
    {
        public int Id { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        public string Diagnose { get; set; }

        public string Treatment { get; set; }

        public DateTime Date { get; set; }
    }
}
