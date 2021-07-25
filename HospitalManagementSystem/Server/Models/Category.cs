using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models
{
    public class Category
    {
        public Category()
        {
            this.Medicines = new HashSet<Medicine>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
