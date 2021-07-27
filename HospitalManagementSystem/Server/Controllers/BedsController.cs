using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Beds;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    public class BedsController : ApiController
    {
        private readonly IBedsService bedsService;

        public BedsController(IBedsService bedsService)
        {
            this.bedsService = bedsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllBedsByFloorIdViewModel>>> GetAll()
        {
            IEnumerable<AllBedsByFloorIdViewModel> viewModel = await this.bedsService.GetAll();
            return this.Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BedByIdViewModel>> GetById(int id)
        {
            BedByIdViewModel viewModel = await this.bedsService.GetById(id);
            return this.Ok(viewModel);
        }
    }
}
