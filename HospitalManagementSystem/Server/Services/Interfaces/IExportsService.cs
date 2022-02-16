using HospitalManagementSystem.Shared.Payments;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IExportsService
    {
        MemoryStream CreatePdf(IEnumerable<AllPaymentsByDoctorIdViewModel> payments);

        MemoryStream CreatePdfSingle(PaymentByIdViewModel payment);
    }
}
