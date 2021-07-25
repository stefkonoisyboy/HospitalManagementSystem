using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Models.Enumerations
{
    public enum AppointmentStatus
    {
        Waiting = 1,
        InProgress = 2,
        Cancelled = 3,
        Finished = 4,
    }
}
