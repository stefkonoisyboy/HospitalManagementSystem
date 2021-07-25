using HospitalManagementSystem.Shared.Treatments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface ITreatmentsService
    {
        Task<IEnumerable<AllTreatmentsByUserIdViewModel>> GetAllTreatmentsByUserIdAsync(string userId);

        Task<IEnumerable<AllTreatmentsByUserIdViewModel>> GetAllTreatmentsByDoctorIdAsync(string doctorId);

        Task<TreatmentByIdViewModel> GetTreatmentById(int id);
    }
}
