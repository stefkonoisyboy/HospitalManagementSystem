using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Payments
{
    public class AllPaymentsByDoctorIdViewModel : AllPaymentsByUserIdViewModel
    {
        public string Patient { get; set; }

        public string Status { get; set; }
    }
}
