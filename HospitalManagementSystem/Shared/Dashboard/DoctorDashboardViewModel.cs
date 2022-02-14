using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Dashboard
{
    public class DoctorDashboardViewModel
    {
        public int PatientsCount { get; set; }

        public int TreatmentsCount { get; set; }

        public int RecipesCount { get; set; }

        public int PaymentsCount { get; set; }
    }
}
