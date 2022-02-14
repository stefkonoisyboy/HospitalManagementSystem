using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Models;
using HospitalManagementSystem.Server.Models.Enumerations;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Appointments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly ApplicationDbContext dbContext;

        public AppointmentsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(CreateAppointmentInputModel input)
        {
            Appointment appointment = new Appointment
            {
                DoctorId = input.DoctorId,
                PatientId = input.PatientId,
                CreatorId = input.CreatorId,
                Title = input.Title,
                Description = input.Description,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                Status = (AppointmentStatus)Enum.Parse(typeof(AppointmentStatus), input.Status),
            };

            await this.dbContext.Appointments.AddAsync(appointment);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DoctorCreateAsync(DoctorCreateAppointmentInputModel input)
        {
            Appointment appointment = new Appointment
            {
                DoctorId = input.DoctorId,
                PatientId = input.PatientId,
                CreatorId = input.CreatorId,
                Title = input.Title,
                Description = input.Description,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                Status = (AppointmentStatus)Enum.Parse(typeof(AppointmentStatus), input.Status),
            };

            await this.dbContext.Appointments.AddAsync(appointment);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DoctorUpdateAsync(int id, DoctorEditAppointmentInputModel input)
        {
            Appointment appointment = await this.dbContext.Appointments.FirstOrDefaultAsync(a => a.Id == id);

            appointment.Description = input.Description;
            appointment.PatientId = input.PatientId;
            appointment.EndDate = input.EndDate;
            appointment.StartDate = input.StartDate;
            appointment.Status = (AppointmentStatus)Enum.Parse(typeof(AppointmentStatus), input.Status);
            appointment.Title = input.Title;

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllAppointmentsByDoctorIdViewModel>> GetAllAppointmentsByDoctorIdViewModel(string doctorId)
        {
            return await this.dbContext.Appointments
                .Where(a => a.DoctorId == doctorId)
                .OrderBy(a => a.Id)
                .Select(a => new AllAppointmentsByDoctorIdViewModel
                {
                    Description = a.Description,
                    Id = a.Id,
                    Patient = a.Patient.FirstName + ' ' + a.Patient.LastName,
                    EndDate = a.EndDate,
                    StartDate = a.StartDate,
                    Status = a.Status.ToString(),
                    Title = a.Title,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllAppointmentsByPatientIdViewModel>> GetAllAppointmentsByPatientId(string patientId)
        {
            return await this.dbContext.Appointments
                .Where(a => a.PatientId == patientId)
                .OrderBy(a => a.Id)
                .Select(a => new AllAppointmentsByPatientIdViewModel
                {
                    Description = a.Description,
                    Id = a.Id,
                    Doctor = a.Doctor.FirstName + ' ' + a.Doctor.LastName,
                    EndDate = a.EndDate,
                    StartDate = a.StartDate,
                    Status = a.Status.ToString(),
                    Title = a.Title,
                })
                .ToListAsync();
        }

        public async Task<EditAppointmentInputModel> GetAppointmentToBeUpdatedAsync(int id)
        {
            return await this.dbContext.Appointments
                .Where(a => a.Id == id)
                .Select(a => new EditAppointmentInputModel
                {
                    Id = a.Id,
                    PatientId = a.PatientId,
                    Description = a.Description,
                    DoctorId = a.DoctorId,
                    EndDate = a.EndDate,
                    StartDate = a.StartDate,
                    Status = a.Status.ToString(),
                    Title = a.Title,
                    CreatorId = a.CreatorId,
                })
                .FirstOrDefaultAsync();
        }

        public AppointmentsCountViewModel GetDifferentTypesOfAppointmentsCount()
        {
            return new AppointmentsCountViewModel
            {
                CancelledAppointments = this.dbContext.Appointments.Count(a => a.Status == AppointmentStatus.Cancelled),
                WaitingAppointments = this.dbContext.Appointments.Count(a => a.Status == AppointmentStatus.Waiting),
                FinishedAppointments = this.dbContext.Appointments.Count(a => a.Status == AppointmentStatus.Finished),
                InProgressAppointments = this.dbContext.Appointments.Count(a => a.Status == AppointmentStatus.InProgress),
            };
        }

        public async Task<DoctorEditAppointmentInputModel> GetDoctorAppointmentToBeUpdatedAsync(int id)
        {
            return await this.dbContext.Appointments
                .Where(a => a.Id == id)
                .Select(a => new DoctorEditAppointmentInputModel
                {
                    Id = a.Id,
                    PatientId = a.PatientId,
                    Description = a.Description,
                    DoctorId = a.DoctorId,
                    EndDate = a.EndDate,
                    StartDate = a.StartDate,
                    Status = a.Status.ToString(),
                    Title = a.Title,
                    CreatorId = a.CreatorId,
                })
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(int id, EditAppointmentInputModel input)
        {
            Appointment appointment = await this.dbContext.Appointments.FirstOrDefaultAsync(a => a.Id == id);

            appointment.Description = input.Description;
            appointment.DoctorId = input.DoctorId;
            appointment.EndDate = input.EndDate;
            appointment.StartDate = input.StartDate;
            appointment.Status = (AppointmentStatus)Enum.Parse(typeof(AppointmentStatus), input.Status);
            appointment.Title = input.Title;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
