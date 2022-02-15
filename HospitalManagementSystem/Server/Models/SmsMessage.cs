using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class SmsMessage
    {
        public int Id { get; set; }

        public string To { get; set; }

        public string From { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
