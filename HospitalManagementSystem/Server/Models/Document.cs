using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class Document
    {
        public Document()
        {
            this.Documentations = new HashSet<DocumentDocumentation>();
        }

        public int Id { get; set; }

        public string RemoteUrl { get; set; }

        public virtual ICollection<DocumentDocumentation> Documentations { get; set; }
    }
}
