using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class Documentation
    {
        public Documentation()
        {
            this.Documents = new HashSet<DocumentDocumentation>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string PatientId { get; set; }

        public virtual ApplicationUser Patient { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<DocumentDocumentation> Documents { get; set; }
    }
}
