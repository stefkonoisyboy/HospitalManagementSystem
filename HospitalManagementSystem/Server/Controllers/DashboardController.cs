using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Dashboard;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    public class DashboardController : ApiController
    {
        private readonly IDashboardService dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }

        [HttpGet]
        public ActionResult<DoctorDashboardViewModel> DoctorDashboard()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            DoctorDashboardViewModel viewModel = this.dashboardService.GetDashboardInfoByCurrentDoctor(userId);
            return this.Ok(viewModel);
        }
    }
}
