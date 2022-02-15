using HospitalManagementSystem.Shared.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.SmsMessages
{
    public class SmsMessageInputModel
    {
        public string To { get; set; }

        public string From { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        public string Text { get; set; }

        public string PatientId { get; set; }

        public string CreatorId { get; set; }

        public IEnumerable<AllPatientsDropDownViewModel> Patients { get; set; }
    }
}
