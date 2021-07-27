using HospitalManagementSystem.Shared.Beds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IBedsService
    {
        Task<BedByIdViewModel> GetById(int id);

        Task<IEnumerable<AllBedsByFloorIdViewModel>> GetAll();
    }
}
