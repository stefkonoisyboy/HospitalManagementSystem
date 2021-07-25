using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Models;
using HospitalManagementSystem.Server.Models.Enumerations;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Appointments;
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
                Title = input.Title,
                Description = input.Description,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                Status = (AppointmentStatus)Enum.Parse(typeof(AppointmentStatus), input.Status),
            };

            await this.dbContext.Appointments.AddAsync(appointment);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
