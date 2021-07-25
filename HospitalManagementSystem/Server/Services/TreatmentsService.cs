using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Treatments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class TreatmentsService : ITreatmentsService
    {
        private readonly ApplicationDbContext dbContext;

        public TreatmentsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllTreatmentsByUserIdViewModel>> GetAllTreatmentsByDoctorIdAsync(string doctorId)
        {
            return await this.dbContext.Treatments
                .Where(t => t.DoctorId == doctorId)
                .OrderBy(t => t.Id)
                .Select(t => new AllTreatmentsByUserIdViewModel
                {
                    Id = t.Id,
                    Date = t.Date,
                    Diagnose = t.Diagnose,
                    Doctor = t.Doctor.FirstName + ' ' + t.Doctor.LastName,
                    Patient = t.Patient.FirstName + ' ' + t.Patient.LastName,
                    Treatment = t.Description,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllTreatmentsByUserIdViewModel>> GetAllTreatmentsByUserIdAsync(string userId)
        {
            return await this.dbContext.Treatments
                .Where(t => t.PatientId == userId)
                .OrderBy(t => t.Id)
                .Select(t => new AllTreatmentsByUserIdViewModel
                {
                    Id = t.Id,
                    Date = t.Date,
                    Diagnose = t.Diagnose,
                    Doctor = t.Doctor.FirstName + ' ' + t.Doctor.LastName,
                    Treatment = t.Description,
                })
                .ToListAsync();
        }

        public async Task<TreatmentByIdViewModel> GetTreatmentById(int id)
        {
            return await this.dbContext.Treatments
                .Where(t => t.Id == id)
                .Select(t => new TreatmentByIdViewModel
                {
                    Date = t.Date,
                    Diagnose = t.Diagnose,
                    Doctor = t.Doctor.FirstName + ' ' + t.Doctor.LastName,
                    Patient = t.Patient.FirstName + ' ' + t.Patient.LastName,
                    DoctorEmail = t.Doctor.Email,
                    Id = t.Id,
                    PatientAddress = t.Patient.Address,
                    PatientCity = t.Patient.City,
                    PatientEmail = t.Patient.Email,
                    PatientPhone = t.Patient.PhoneNumber,
                    PatientState = t.Patient.State,
                    Treatment = t.Description
                })
                .FirstOrDefaultAsync();
        }
    }
}
