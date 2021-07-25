using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Recipes
{
    public class AllRecipesByUserIdViewModel
    {
        public int Id { get; set; }

        public string Doctor { get; set; }

        public string Description { get; set; }

        public string OtherInfo { get; set; }

        public IEnumerable<string> Medicines { get; set; }

        public DateTime Date { get; set; }
    }
}
