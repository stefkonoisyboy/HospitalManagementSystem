using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.BloodTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    public class BloodTypesController : ApiController
    {
        private readonly IBloodTypesService bloodTypesService;

        public BloodTypesController(IBloodTypesService bloodTypesService)
        {
            this.bloodTypesService = bloodTypesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllBloodTypesViewModel>>> GetAll()
        {
            IEnumerable<AllBloodTypesViewModel> viewModel = await this.bloodTypesService.GetAll();
            return this.Ok(viewModel);
        }
    }
}
