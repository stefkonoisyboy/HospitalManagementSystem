using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Payments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    [Authorize]
    public class PaymentsController : ApiController
    {
        private readonly IPaymentsService paymentsService;

        public PaymentsController(IPaymentsService paymentsService)
        {
            this.paymentsService = paymentsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllPaymentsByUserIdViewModel>>> AllByUserId()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<AllPaymentsByUserIdViewModel> viewModel = await this.paymentsService.GetAllPaymentsByUserIdAsync(userId);

            return this.Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentByIdViewModel>> Details(int id)
        {
            PaymentByIdViewModel viewModel = await this.paymentsService.GetPaymentByIdAsync(id);
            return this.Ok(viewModel);
        }
    }
}
