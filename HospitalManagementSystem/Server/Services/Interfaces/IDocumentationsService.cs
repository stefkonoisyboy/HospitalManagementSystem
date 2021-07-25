using HospitalManagementSystem.Shared.Documentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IDocumentationsService
    {
        Task<IEnumerable<AllDocumentationsByUserIdViewModel>> GetAllDocumentationsByUserIdAsync(string userId);
    }
}
