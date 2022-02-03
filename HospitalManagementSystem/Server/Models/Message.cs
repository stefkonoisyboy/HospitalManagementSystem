using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class Message
    {
        public Message()
        {
            this.Users = new HashSet<UserMessage>();
        }

        public int Id { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsSeen { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public int? ParentId { get; set; }

        public virtual Message Parent { get; set; }

        public virtual ICollection<UserMessage> Users { get; set; }
    }
}
