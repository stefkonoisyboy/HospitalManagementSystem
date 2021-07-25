using HospitalManagementSystem.Shared.Infrastructure.ValidationAttributes;
using HospitalManagementSystem.Shared.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Appointments
{
    public class CreateAppointmentInputModel : IValidatableObject
    {
        [Required]
        public string DoctorId { get; set; }

        public IEnumerable<AllDoctorsDropDownViewModel> Doctors { get; set; }

        public string PatientId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Title { get; set; }

        [StartDate]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.StartDate > this.EndDate)
            {
                yield return new ValidationResult("Start Date should be lower than End Date!");
            }
        }
    }
}
