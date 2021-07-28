using HospitalManagementSystem.Shared.BloodTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IBloodTypesService
    {
        Task<IEnumerable<AllBloodTypesDropDownViewModel>> GetAllBloodTypes();

        Task<IEnumerable<AllBloodTypesViewModel>> GetAll();
    }
}
