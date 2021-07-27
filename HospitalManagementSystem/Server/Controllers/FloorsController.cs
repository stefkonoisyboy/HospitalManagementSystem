using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Floors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    public class FloorsController : ApiController
    {
        private readonly IFloorsService floorsService;

        public FloorsController(IFloorsService floorsService)
        {
            this.floorsService = floorsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllFloorsDropDownViewModel>>> GetAllForDropDown()
        {
            IEnumerable<AllFloorsDropDownViewModel> viewModel = await this.floorsService.GetAllForNavMenu();
            return this.Ok(viewModel);
        }
    }
}
