using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Floors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class FloorsService : IFloorsService
    {
        private readonly ApplicationDbContext dbContext;

        public FloorsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }        

        public async Task<IEnumerable<AllFloorsDropDownViewModel>> GetAllForNavMenu()
        {
            return await this.dbContext.Floors
                .OrderBy(f => f.Id)
                .Select(f => new AllFloorsDropDownViewModel
                {
                    Id = f.Id,
                    Name = f.Name,
                })
                .ToListAsync();
        }
    }
}
