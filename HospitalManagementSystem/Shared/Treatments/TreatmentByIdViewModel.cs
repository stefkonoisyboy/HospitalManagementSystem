using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Treatments
{
    public class TreatmentByIdViewModel
    {
        public int Id { get; set; }

        public string PatientAddress { get; set; }

        public string PatientCity { get; set; }

        public string PatientEmail { get; set; }

        public string PatientPhone { get; set; }

        public string PatientState { get; set; }

        public string Doctor { get; set; }

        public string Patient { get; set; }

        public string DoctorEmail { get; set; }

        public DateTime Date { get; set; }

        public string Diagnose { get; set; }

        public string Treatment { get; set; }
    }
}
