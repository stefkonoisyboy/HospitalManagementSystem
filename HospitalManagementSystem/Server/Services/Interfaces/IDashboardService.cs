using HospitalManagementSystem.Shared.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IDashboardService
    {
        DoctorDashboardViewModel GetDashboardInfoByCurrentDoctor(string doctorId);
    }
}
