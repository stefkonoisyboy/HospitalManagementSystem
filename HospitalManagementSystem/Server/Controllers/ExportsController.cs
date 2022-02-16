using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Payments;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    public class ExportsController : ApiController
    {
        private readonly IExportsService exportsService;
        private readonly IPaymentsService paymentsService;

        public ExportsController(IExportsService exportsService, IPaymentsService paymentsService)
        {
            this.exportsService = exportsService;
            this.paymentsService = paymentsService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<byte[]>> GetStreamPDF()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<AllPaymentsByDoctorIdViewModel> payments = await this.paymentsService.GetAllPaymentsByDoctorIdAsync(userId);
            MemoryStream memoryStream = this.exportsService.CreatePdf(payments);

            return this.Ok(memoryStream.ToArray());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<byte[]>> GetStreamSinglePDF(int id)
        {
            PaymentByIdViewModel payment = await this.paymentsService.GetPaymentByIdAsync(id);
            MemoryStream memoryStream = this.exportsService.CreatePdfSingle(payment);

            return this.Ok(memoryStream.ToArray());
        }
    }
}
