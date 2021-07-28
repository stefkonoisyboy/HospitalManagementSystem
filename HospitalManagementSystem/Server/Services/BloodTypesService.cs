using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.BloodTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class BloodTypesService : IBloodTypesService
    {
        private readonly ApplicationDbContext dbContext;

        public BloodTypesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllBloodTypesViewModel>> GetAll()
        {
            return await this.dbContext.BloodTypes
                .OrderBy(bt => bt.Id)
                .Select(bt => new AllBloodTypesViewModel
                {
                    Id = bt.Id,
                    Name = bt.Name,
                    Quantity = bt.Quantity,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllBloodTypesDropDownViewModel>> GetAllBloodTypes()
        {
            return await this.dbContext.BloodTypes
                .Select(bt => new AllBloodTypesDropDownViewModel
                {
                    Id = bt.Id,
                    Name = bt.Name,
                })
                .ToListAsync();
        }
    }
}
