using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Messages
{
    public class ReceivedMessageByIdViewModel
    {
        public string Creator { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
