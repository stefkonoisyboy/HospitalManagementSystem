using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext dbContext;

        public DashboardService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DoctorDashboardViewModel GetDashboardInfoByCurrentDoctor(string doctorId)
        {
            return new DoctorDashboardViewModel
            {
                PatientsCount = dbContext.Users.Count(u => u.Role == "Patient"),
                PaymentsCount = dbContext.Payments.Count(p => p.DoctorId == doctorId),
                RecipesCount = dbContext.Recipes.Count(p => p.DoctorId == doctorId),
                TreatmentsCount = dbContext.Treatments.Count(p => p.DoctorId == doctorId),
            };
        }
    }
}
