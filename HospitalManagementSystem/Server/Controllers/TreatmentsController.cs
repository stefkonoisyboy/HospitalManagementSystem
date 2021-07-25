using AspNetCore.Reporting;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Treatments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    [Authorize]
    public class TreatmentsController : ApiController
    {
        private readonly ITreatmentsService treatmentsService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public TreatmentsController(ITreatmentsService treatmentsService, IWebHostEnvironment webHostEnvironment)
        {
            this.treatmentsService = treatmentsService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllTreatmentsByUserIdViewModel>>> AllByUserId()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<AllTreatmentsByUserIdViewModel> viewModel = await this.treatmentsService.GetAllTreatmentsByUserIdAsync(userId);

            return this.Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TreatmentByIdViewModel>> Details(int id)
        {
            TreatmentByIdViewModel viewModel = await this.treatmentsService.GetTreatmentById(id);
            return this.Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AllTreatmentsByUserIdViewModel>>> AllByDoctorId(string id)
        {
            IEnumerable<AllTreatmentsByUserIdViewModel> viewModel = await this.treatmentsService.GetAllTreatmentsByDoctorIdAsync(id);
            return this.Ok(viewModel);
        }
    }
}
