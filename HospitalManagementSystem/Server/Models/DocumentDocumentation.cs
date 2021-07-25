using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class DocumentDocumentation
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }

        public virtual Document Document { get; set; }

        public int DocumentationId { get; set; }

        public virtual Documentation Documentation { get; set; }
    }
}
