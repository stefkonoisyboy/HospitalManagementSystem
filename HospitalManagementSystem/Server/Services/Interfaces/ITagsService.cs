using HospitalManagementSystem.Shared.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface ITagsService
    {
        Task<IEnumerable<AllTagsForDropDownViewModel>> GetAllForDropDown();
    }
}
