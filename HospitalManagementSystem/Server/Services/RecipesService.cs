using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Recipes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class RecipesService : IRecipesService
    {
        private readonly ApplicationDbContext dbContext;

        public RecipesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllRecipesByUserIdViewModel>> GetAllRecipesByDoctorIdAsync(string doctorId)
        {
            return await this.dbContext.Recipes
                .Where(r => r.DoctorId == doctorId)
                .OrderBy(r => r.Id)
                .Select(r => new AllRecipesByUserIdViewModel
                {
                    Id = r.Id,
                    Date = r.Date,
                    Description = r.Description,
                    Doctor = r.Doctor.FirstName + ' ' + r.Doctor.LastName,
                    OtherInfo = r.OtherInformation,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllRecipesByUserIdViewModel>> GetAllRecipesByUserIdAsync(string userId)
        {
            return await this.dbContext.Recipes
                .Where(r => r.PatientId == userId)
                .OrderBy(r => r.Id)
                .Select(r => new AllRecipesByUserIdViewModel
                {
                    Id = r.Id,
                    Date = r.Date,
                    Description = r.Description,
                    Doctor = r.Doctor.FirstName + ' ' + r.Doctor.LastName,
                    OtherInfo = r.OtherInformation,
                    Medicines = r.Medicines
                    .Select(m => m.Medicine.MedicineName)
                    .ToList(),
                })
                .ToListAsync();
        }

        public async Task<RecipeByIdViewModel> GetRecipeById(int id)
        {
            return await this.dbContext.Recipes
                .Where(r => r.Id == id)
                .Select(r => new RecipeByIdViewModel
                {
                    Date = r.Date,
                    Description = r.Description,
                    Doctor = r.Doctor.FirstName + ' ' + r.Doctor.LastName,
                    Patient = r.Patient.FirstName + ' ' + r.Patient.LastName,
                    DoctorEmail = r.Doctor.Email,
                    Id = r.Id,
                    PatientAddress = r.Patient.Address,
                    PatientCity = r.Patient.City,
                    PatientEmail = r.Patient.Email,
                    PatientPhone = r.Patient.PhoneNumber,
                    PatientState = r.Patient.State,
                    OtherInfo = r.OtherInformation,
                    Medicines = r.Medicines
                    .Select(m => m.Medicine.MedicineName)
                    .ToList(),
                })
                .FirstOrDefaultAsync();
        }
    }
}
