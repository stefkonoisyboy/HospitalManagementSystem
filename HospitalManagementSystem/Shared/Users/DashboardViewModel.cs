using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Users
{
    public class DashboardViewModel
    {
        public int PaymentsCount { get; set; }

        public int TreatmentsCount { get; set; }

        public int RecipesCount { get; set; }

        public int DoctorsCount { get; set; }
    }
}
