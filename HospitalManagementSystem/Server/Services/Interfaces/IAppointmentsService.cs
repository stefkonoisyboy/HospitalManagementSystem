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

        Task DoctorCreateAsync(DoctorCreateAppointmentInputModel input);

        Task UpdateAsync(int id, EditAppointmentInputModel input);

        Task DoctorUpdateAsync(int id, DoctorEditAppointmentInputModel input);

        Task DeleteAsync(int id);

        AppointmentsCountViewModel GetDifferentTypesOfAppointmentsCount();

        Task<EditAppointmentInputModel> GetAppointmentToBeUpdatedAsync(int id);

        Task<DoctorEditAppointmentInputModel> GetDoctorAppointmentToBeUpdatedAsync(int id);

        Task<IEnumerable<AllAppointmentsByPatientIdViewModel>> GetAllAppointmentsByPatientId(string patientId);

        Task<IEnumerable<AllAppointmentsByDoctorIdViewModel>> GetAllAppointmentsByDoctorIdViewModel(string doctorId);
    }
}
