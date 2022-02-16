using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared;
using HospitalManagementSystem.Shared.Appointments;
using HospitalManagementSystem.Shared.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Vonage;
using Vonage.Request;

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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllAppointmentsByPatientIdViewModel>>> GetAllAppointmentsByPatientId()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<AllAppointmentsByPatientIdViewModel> viewModel = await this.appointmentsService.GetAllAppointmentsByPatientId(userId);
            return this.Ok(viewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllAppointmentsByDoctorIdViewModel>>> GetAllAppointmentsByDoctorId()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<AllAppointmentsByDoctorIdViewModel> viewModel = await this.appointmentsService.GetAllAppointmentsByDoctorIdViewModel(userId);
            return this.Ok(viewModel);
        }

        [HttpGet]
        public ActionResult<AppointmentsCountViewModel> GetCounts()
        {
            AppointmentsCountViewModel viewModel = this.appointmentsService.GetDifferentTypesOfAppointmentsCount();
            return this.Ok(viewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<CreateAppointmentInputModel>> Create()
        {
            CreateAppointmentInputModel input = new CreateAppointmentInputModel
            {
                Doctors = await this.usersService.GetAllDoctorsForDropDown(),
            };

            return this.Ok(input);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<DoctorCreateAppointmentInputModel>> DoctorCreate()
        {
            DoctorCreateAppointmentInputModel input = new DoctorCreateAppointmentInputModel
            {
                Patients = await this.usersService.GetAllPatientsForDropDown(),
            };

            return this.Ok(input);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<EditAppointmentInputModel>> Edit(int id)
        {
            EditAppointmentInputModel input = await this.appointmentsService.GetAppointmentToBeUpdatedAsync(id);
            input.Doctors = await this.usersService.GetAllDoctorsForDropDown();
            return this.Ok(input);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorEditAppointmentInputModel>> DoctorEdit(int id)
        {
            DoctorEditAppointmentInputModel input = await this.appointmentsService.GetDoctorAppointmentToBeUpdatedAsync(id);
            input.Patients = await this.usersService.GetAllPatientsForDropDown();
            return this.Ok(input);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Doctors = await this.usersService.GetAllDoctorsForDropDown();
                return this.BadRequest(input);
            }

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string from = this.usersService.GetPhoneNumberByUserId(userId);
            string to = this.usersService.GetPhoneNumberByUserId(input.DoctorId);

            try
            {

                var credentials = Credentials.FromApiKeyAndSecret(
        "9e66f8c5",
        "GzKGcpFOVeT4PV6a"
        );

                var vonageClient = new VonageClient(credentials);

                var response = vonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
                {
                    To = to,
                    From = from,
                    Text = "Your appointment is ready! Log into your account to see more details!",
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("To: " + to);
            }

            input.PatientId = userId;
            input.CreatorId = userId;
            await this.appointmentsService.CreateAsync(input);

            return this.Ok();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DoctorCreate(DoctorCreateAppointmentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Patients = await this.usersService.GetAllPatientsForDropDown();
                return this.BadRequest(input);
            }

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string from = this.usersService.GetPhoneNumberByUserId(userId);
            string to = this.usersService.GetPhoneNumberByUserId(input.PatientId);

            try
            {

                var credentials = Credentials.FromApiKeyAndSecret(
        "9e66f8c5",
        "GzKGcpFOVeT4PV6a"
        );

                var vonageClient = new VonageClient(credentials);

                var response = vonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
                {
                    To = to,
                    From = from,
                    Text = "Your appointment is ready! Log into your account to see more details!",
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("To: " + to);
            }

            input.DoctorId = userId;
            input.CreatorId = userId;
            await this.appointmentsService.DoctorCreateAsync(input);

            return this.Ok();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Edit(EditAppointmentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Doctors = await this.usersService.GetAllDoctorsForDropDown();
                return this.BadRequest(input);
            }

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string from = this.usersService.GetPhoneNumberByUserId(userId);
            string to = this.usersService.GetPhoneNumberByUserId(input.DoctorId);

            try
            {

                var credentials = Credentials.FromApiKeyAndSecret(
        "9e66f8c5",
        "GzKGcpFOVeT4PV6a"
        );

                var vonageClient = new VonageClient(credentials);

                var response = vonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
                {
                    To = to,
                    From = from,
                    Text = "Your appointment was updated! Log into your account to see more details!",
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("To: " + to);
            }

            await this.appointmentsService.UpdateAsync(input.Id, input);

            return this.Ok();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> DoctorEdit(DoctorEditAppointmentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Patients = await this.usersService.GetAllPatientsForDropDown();
                return this.BadRequest(input);
            }

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            string from = this.usersService.GetPhoneNumberByUserId(userId);
            string to = this.usersService.GetPhoneNumberByUserId(input.PatientId);

            try
            {

                var credentials = Credentials.FromApiKeyAndSecret(
        "9e66f8c5",
        "GzKGcpFOVeT4PV6a"
        );

                var vonageClient = new VonageClient(credentials);

                var response = vonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
                {
                    To = to,
                    From = from,
                    Text = "Your appointment was updated! Log into your account to see more details!",
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("To: " + to);
            }

            await this.appointmentsService.DoctorUpdateAsync(input.Id, input);

            return this.Ok();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await this.appointmentsService.DeleteAsync(id);
            return this.Ok();
        }
    }
}
