using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Models;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.SmsMessages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vonage;
using Vonage.Messaging;
using Vonage.Request;

namespace HospitalManagementSystem.Server.Services
{
    public class SmsService : ISmsService
    {
        private readonly ApplicationDbContext dbContext;

        public SmsService(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            this.Configuration = configuration;
            this.dbContext = dbContext;
        }

        public IConfiguration Configuration { get; set; }

        public async Task<IEnumerable<AllSmsMessagesByCreatorIdViewModel>> GetAllByCreatorId(string creatorId)
        {
            return await this.dbContext.SmsMessages
                .Where(s => s.CreatorId == creatorId)
                .OrderByDescending(s => s.CreatedOn)
                .Select(s => new AllSmsMessagesByCreatorIdViewModel
                {
                    Id = s.Id,
                    PhoneNumber = s.To,
                    Text = s.Text,
                    Title = s.Title,
                })
                .ToListAsync();
        }

        public async Task SendSms(SmsMessageInputModel input)
        {
           
            SmsMessage sms = new SmsMessage
            {
                To = input.To,
                From = input.From,
                Text = input.Text,
                Title = input.Title,
                CreatorId = input.CreatorId,
                CreatedOn = DateTime.UtcNow,
            };

            await this.dbContext.SmsMessages.AddAsync(sms);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
