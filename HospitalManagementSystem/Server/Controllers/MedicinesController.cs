using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Medicines;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    public class MedicinesController : ApiController
    {
        private readonly IMedicinesService medicinesService;

        public MedicinesController(IMedicinesService medicinesService)
        {
            this.medicinesService = medicinesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllMedicinesViewModel>>> GetAll()
        {
            IEnumerable<AllMedicinesViewModel> viewModel = await this.medicinesService.GetAll();
            return this.Ok(viewModel);
        }
    }
}
