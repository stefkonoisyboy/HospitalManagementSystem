using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Tags;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class TagsService : ITagsService
    {
        private readonly ApplicationDbContext dbContext;

        public TagsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllTagsForDropDownViewModel>> GetAllForDropDown()
        {
            return await this.dbContext.Tags
                .OrderBy(t => t.Name)
                .Select(t => new AllTagsForDropDownViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToListAsync();
        }
    }
}
