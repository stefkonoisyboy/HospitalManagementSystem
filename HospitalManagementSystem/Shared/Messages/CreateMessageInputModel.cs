using HospitalManagementSystem.Shared.Infrastructure.ValidationAttributes;
using HospitalManagementSystem.Shared.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Messages
{
    public class CreateMessageInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Subject { get; set; }

        [Required]
        [MinLength(2)]
        public string Content { get; set; }

        public string CreatorId { get; set; }

        [Count(ErrorMessage = "You should select at least 1 user to send this message!")]
        public IEnumerable<string> UserIds { get; set; }

        public IEnumerable<ReceiversMessageDropDownViewModel> Users { get; set; }
    }
}
