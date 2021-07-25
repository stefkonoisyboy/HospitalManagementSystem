using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Documentations
{
    public class AllDocumentationsByUserIdViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Patient { get; set; }

        public IEnumerable<string> Documents { get; set; }

        public DateTime Date { get; set; }
    }
}
