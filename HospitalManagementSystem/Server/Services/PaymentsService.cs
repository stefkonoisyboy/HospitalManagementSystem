using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Payments;
using HospitalManagementSystem.Shared.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class PaymentsService : IPaymentsService
    {
        private readonly ApplicationDbContext dbContext;

        public PaymentsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllPaymentsByDoctorIdViewModel>> GetAllPaymentsByDoctorIdAsync(string doctorId)
        {
            return await this.dbContext.Payments
               .Where(p => p.DoctorId == doctorId)
               .OrderBy(p => p.Id)
               .Select(p => new AllPaymentsByDoctorIdViewModel
               {
                   Id = p.Id,
                   Date = p.Date,
                   Doctor = p.Doctor.FirstName + ' ' + p.Doctor.LastName,
                   Patient = p.Patient.FirstName + ' ' + p.Patient.LastName,
                   Title = p.Title,
                   Status = p.Status.ToString(),
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<AllPaymentsByUserIdViewModel>> GetAllPaymentsByUserIdAsync(string userId)
        {
            return await this.dbContext.Payments
                .Where(p => p.PatientId == userId)
                .OrderBy(p => p.Id)
                .Select(p => new AllPaymentsByUserIdViewModel
                {
                    Id = p.Id,
                    Date = p.Date,
                    Doctor = p.Doctor.FirstName + ' ' + p.Doctor.LastName,
                    Title = p.Title,
                    Total = p.Products.Sum(pr => pr.Product.Price * (decimal)pr.Quantity - (pr.Product.Price * (decimal)pr.Quantity) * ((decimal)pr.Discount / 100)),
                })
                .ToListAsync();
        }

        public async Task<PaymentByIdViewModel> GetPaymentByIdAsync(int id)
        {
            return await this.dbContext.Payments
                .Where(p => p.Id == id)
                .Select(p => new PaymentByIdViewModel
                {
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Id = p.Id,
                    OtherInfo = p.OtherInformation,
                    Patient = p.Patient.FirstName + ' ' + p.Patient.LastName,
                    PatientAddress = p.Patient.Address,
                    PatientCity = p.Patient.City,
                    PatientEmail = p.Patient.Email,
                    PatientPhone = p.Patient.PhoneNumber,
                    PatientState = p.Patient.State,
                    Status = ((int)p.Status),
                    Products = p.Products
                    .Select(pr => new AllProductByPaymentViewModel
                    {
                        Discount = pr.Discount,
                        Name = pr.Product.Name,
                        Price = pr.Product.Price,
                        Quantity = pr.Quantity,
                    })
                    .ToList(),
                })
                .FirstOrDefaultAsync();
        }
    }
}
