using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class Treatment
    {
        public int Id { get; set; }

        public string DoctorId { get; set; }

        public virtual ApplicationUser Doctor { get; set; }

        public string PatientId { get; set; }

        public virtual ApplicationUser Patient { get; set; }

        public string Diagnose { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
