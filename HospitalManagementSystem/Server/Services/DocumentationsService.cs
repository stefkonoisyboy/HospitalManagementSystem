using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Documentations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class DocumentationsService : IDocumentationsService
    {
        private readonly ApplicationDbContext dbContext;

        public DocumentationsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllDocumentationsByUserIdViewModel>> GetAllDocumentationsByUserIdAsync(string userId)
        {
            return await this.dbContext.Documentations
                .Where(d => d.PatientId == userId)
                .OrderBy(d => d.Id)
                .Select(d => new AllDocumentationsByUserIdViewModel
                {
                    Id = d.Id,
                    Title = d.Title,
                    Patient = d.Patient.FirstName + ' ' + d.Patient.LastName,
                    Documents = d.Documents
                    .Select(doc => doc.Document.RemoteUrl)
                    .ToList(),
                    Date = d.Date,
                })
                .ToListAsync();
        }
    }
}
