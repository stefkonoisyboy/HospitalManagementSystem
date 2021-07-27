using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Beds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class BedsService : IBedsService
    {
        private readonly ApplicationDbContext dbContext;

        public BedsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllBedsByFloorIdViewModel>> GetAll()
        {
            return await this.dbContext.Beds
                .OrderBy(b => b.Id)
                .Select(b => new AllBedsByFloorIdViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Status = b.Status.ToString(),
                    Type = b.Type.ToString(),
                    Floor = b.Room.Floor.Name,
                    Room = b.Room.Name,
                })
                .ToListAsync();
        }

        public async Task<BedByIdViewModel> GetById(int id)
        {
            return await this.dbContext.Beds
                .Where(b => b.Id == id)
                .Select(b => new BedByIdViewModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Status = b.Status.ToString(),
                    Type = b.Type.ToString(),
                    PricePerDay = b.PricePerDay,
                    RemoteImageUrl = b.RemoteImageUrl,
                    Floor = this.dbContext.Floors.FirstOrDefault(f => f.Rooms.Any(r => r.Id == b.RoomId)).Name,
                    Room = b.Room.Name,
                })
                .FirstOrDefaultAsync();
        }
    }
}
