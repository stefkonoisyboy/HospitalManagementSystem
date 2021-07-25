using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Appointments;
using HospitalManagementSystem.Shared.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    public class AppointmentsController : ApiController
    {
        private readonly IAppointmentsService appointmentsService;
        private readonly IUsersService usersService;

        public AppointmentsController(IAppointmentsService appointmentsService, IUsersService usersService)
        {
            this.appointmentsService = appointmentsService;
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllDoctorsDropDownViewModel>>> Create()
        {
            CreateAppointmentInputModel input = new CreateAppointmentInputModel
            {
                Doctors = await this.usersService.GetAllDoctorsForDropDown(),
            };

            return this.Ok(input);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Doctors = await this.usersService.GetAllDoctorsForDropDown();
                return this.BadRequest(input);
            }

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            input.PatientId = userId;
            await this.appointmentsService.CreateAsync(input);

            return this.Ok();
        }
    }
}
