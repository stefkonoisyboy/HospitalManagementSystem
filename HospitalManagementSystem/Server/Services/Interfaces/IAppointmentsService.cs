using HospitalManagementSystem.Shared.Appointments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IAppointmentsService
    {
        Task CreateAsync(CreateAppointmentInputModel input);

        Task UpdateAsync(int id, EditAppointmentInputModel input);

        AppointmentsCountViewModel GetDifferentTypesOfAppointmentsCount();

        Task<EditAppointmentInputModel> GetAppointmentToBeUpdatedAsync(int id);

        Task<IEnumerable<AllAppointmentsByPatientIdViewModel>> GetAllAppointmentsByPatientId(string patientId);
    }
}
