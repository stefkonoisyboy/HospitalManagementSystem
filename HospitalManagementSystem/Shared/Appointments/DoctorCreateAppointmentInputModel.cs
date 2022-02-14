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
    public class DoctorCreateAppointmentInputModel
    {
        [Display(Name = "Doctor")]
        [Required]
        public string PatientId { get; set; }

        public IEnumerable<AllPatientsDropDownViewModel> Patients { get; set; }

        public string DoctorId { get; set; }

        public string CreatorId { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Title { get; set; }

        [StartDate(ErrorMessage = "Start Date Should Be Greater Than Current Date!")]

        public DateTime StartDate { get; set; }

        [StartDate(ErrorMessage = "End Date Should Be Greater Than Current Date!")]
        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
