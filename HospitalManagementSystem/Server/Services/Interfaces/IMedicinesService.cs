using HospitalManagementSystem.Shared.Medicines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IMedicinesService
    {
        Task<IEnumerable<AllMedicinesViewModel>> GetAll();
    }
}
