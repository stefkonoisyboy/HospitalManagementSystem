using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Appointments
{
    public class AppointmentsCountViewModel
    {
        public int FinishedAppointments { get; set; }

        public int InProgressAppointments { get; set; }

        public int CancelledAppointments { get; set; }

        public int WaitingAppointments { get; set; }
    }
}
