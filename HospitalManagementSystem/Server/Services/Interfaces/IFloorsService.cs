using HospitalManagementSystem.Shared.Floors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IFloorsService
    {
        Task<IEnumerable<AllFloorsDropDownViewModel>> GetAllForNavMenu();
    }
}
