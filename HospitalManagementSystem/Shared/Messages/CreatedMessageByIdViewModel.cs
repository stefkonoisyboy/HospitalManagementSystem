using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Messages
{
    public class CreatedMessageByIdViewModel
    {
        public IEnumerable<string> Receivers { get; set; } = new List<string>();

        public string Creator { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
