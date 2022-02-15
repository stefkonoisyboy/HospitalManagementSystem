using HospitalManagementSystem.Shared.SmsMessages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vonage.Messaging;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface ISmsService
    {
        Task SendSms(SmsMessageInputModel input);

        Task<IEnumerable<AllSmsMessagesByCreatorIdViewModel>> GetAllByCreatorId(string creatorId);

        IConfiguration Configuration { get; set; }
    }
}
