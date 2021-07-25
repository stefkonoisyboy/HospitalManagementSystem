using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Medicines = new HashSet<RecipeMedicine>();
        }

        public int Id { get; set; }

        public string DoctorId { get; set; }

        public virtual ApplicationUser Doctor { get; set; }

        public string PatientId { get; set; }

        public virtual ApplicationUser Patient { get; set; }

        public string Description { get; set; }

        public string OtherInformation { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<RecipeMedicine> Medicines { get; set; }
    }
}
