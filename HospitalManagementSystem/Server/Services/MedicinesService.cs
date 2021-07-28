using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Medicines;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class MedicinesService : IMedicinesService
    {
        private readonly ApplicationDbContext dbContext;

        public MedicinesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllMedicinesViewModel>> GetAll()
        {
            return await this.dbContext.Medicines
                .OrderBy(m => m.Id)
                .Select(m => new AllMedicinesViewModel
                {
                    Id = m.Id,
                    MedicineName = m.MedicineName,
                    GenericName = m.GenericName,
                    ExpiryDate = m.ExpiryDate,
                    Price = m.Price,
                    Quantity = m.Quantity,
                    Category = m.Category.Name,
                })
                .ToListAsync();
        }
    }
}
