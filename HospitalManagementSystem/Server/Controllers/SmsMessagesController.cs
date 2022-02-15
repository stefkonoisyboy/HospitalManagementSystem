using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.SmsMessages;
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
    public class SmsMessagesController : ApiController
    {
        private readonly ISmsService smsService;
        private readonly IUsersService usersService;

        public SmsMessagesController(ISmsService smsService, IUsersService usersService)
        {
            this.smsService = smsService;
            this.usersService = usersService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllSmsMessagesByCreatorIdViewModel>>> GetAllByCreatorId()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<AllSmsMessagesByCreatorIdViewModel> viewModel = await this.smsService.GetAllByCreatorId(userId);
            return this.Ok(viewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<SmsMessageInputModel>> Create()
        {
            SmsMessageInputModel input = new SmsMessageInputModel
            {
                Patients = await this.usersService.GetAllPatientsForDropDown(),
            };
            return this.Ok(input);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(SmsMessageInputModel input)
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
                    Text = input.Text,
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("To: " + to);
            }

            input.To = to;
            input.From = from;
            input.CreatorId = userId;
            await this.smsService.SendSms(input);

            return this.Ok();
        }
    }
}
