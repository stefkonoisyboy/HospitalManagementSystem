using HospitalManagementSystem.Shared.Payments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IPaymentsService
    {
        Task<IEnumerable<AllPaymentsByUserIdViewModel>> GetAllPaymentsByUserIdAsync(string userId);

        Task<IEnumerable<AllPaymentsByDoctorIdViewModel>> GetAllPaymentsByDoctorIdAsync(string doctorId);

        Task<PaymentByIdViewModel> GetPaymentByIdAsync(int id);
    }
}
