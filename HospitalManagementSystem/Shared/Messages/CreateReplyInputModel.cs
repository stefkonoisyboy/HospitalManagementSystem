using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Messages
{
    public class CreateReplyInputModel
    {
        [Required]
        [MinLength(2)]
        public string Content { get; set; }

        public string CreatorId { get; set; }

        public int ParentId { get; set; }
    }
}
