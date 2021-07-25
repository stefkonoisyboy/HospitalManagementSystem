using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Models;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly ApplicationDbContext dbContext;

        public MessagesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(CreateMessageInputModel input)
        {
            Message message = new Message
            {
                Content = input.Content,
                Subject = input.Content,
                CreatorId = input.CreatorId,
                CreatedOn = DateTime.UtcNow,
            };

            await this.dbContext.Messages.AddAsync(message);
            await this.dbContext.SaveChangesAsync();

            foreach (var userId in input.UserIds)
            {
                UserMessage userMessage = new UserMessage
                {
                    UserId = userId,
                    MessageId = message.Id,
                };

                await this.dbContext.UserMessages.AddAsync(userMessage);
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task CreateReplyAsync(CreateReplyInputModel input)
        {
            Message message = await this.dbContext.Messages.FirstOrDefaultAsync(m => m.Id == input.ParentId);

            Message reply = new Message
            {
                Content = input.Content,
                CreatorId = input.CreatorId,
                ParentId = input.ParentId,
                CreatedOn = DateTime.UtcNow,
                Subject = "Re: " + message.Subject,
            };

            await this.dbContext.Messages.AddAsync(reply);
            await this.dbContext.SaveChangesAsync();

            UserMessage userMessage = new UserMessage
            {
                UserId = reply.Parent.CreatorId,
                MessageId = reply.Id,
            };

            await this.dbContext.UserMessages.AddAsync(userMessage);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(IEnumerable<int> messages)
        {
            foreach (var message in messages)
            {
                Message dbMessage = await this.dbContext.Messages.FirstOrDefaultAsync(m => m.Id == message);
                this.dbContext.Messages.Remove(dbMessage);
            }

            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            Message message = await this.dbContext.Messages.FirstOrDefaultAsync(m => m.Id == id);
            this.dbContext.Messages.Remove(message);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllMessagesByUserIdViewModel>> GetAllMessagesByCreatorIdAsync(string creatorId)
        {
            return await this.dbContext.Messages
                .Where(m => m.CreatorId == creatorId)
                .OrderByDescending(m => m.CreatedOn)
                .Select(m => new AllMessagesByUserIdViewModel
                {
                    Id = m.Id,
                    Content = m.Content,
                    CreatedOn = m.CreatedOn,
                    Creator = m.Creator.FirstName + ' ' + m.Creator.LastName,
                    Subject = m.Subject,
                    CreatorLabelClass = m.Creator.LabelClass,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllMessagesByUserIdViewModel>> GetAllMessagesByReceiverIdAsync(string receiverId)
        {
            return await this.dbContext.Messages
                .Where(m => m.Users.Any(u => u.UserId == receiverId))
                .OrderByDescending(m => m.CreatedOn)
                .Select(m => new AllMessagesByUserIdViewModel
                {
                    Id = m.Id,
                    Content = m.Content,
                    CreatedOn = m.CreatedOn,
                    Creator = m.Creator.FirstName + ' ' + m.Creator.LastName,
                    Subject = m.Subject,
                    CreatorLabelClass = m.Creator.LabelClass,
                })
                .ToListAsync();
        }

        public async Task<CreatedMessageByIdViewModel> GetCreatedMessageByIdAsync(int id)
        {
            return await this.dbContext.Messages
                .Where(m => m.Id == id)
                .Select(m => new CreatedMessageByIdViewModel
                {
                    CreatedOn = DateTime.UtcNow,
                    Content = m.Content,
                    Creator = m.Creator.FirstName + ' ' + m.Creator.LastName,
                    Subject = m.Subject,
                    Receivers = m.Users
                    .Select(u => u.User.FirstName + ' ' + u.User.LastName)
                    .ToList(),
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ReceivedMessageByIdViewModel> GetReceivedMessageByIdAsync(int id)
        {
            return await this.dbContext.Messages
                .Where(m => m.Id == id)
                .Select(m => new ReceivedMessageByIdViewModel
                {
                    Content = m.Content,
                    Subject = m.Subject,
                    CreatedOn = m.CreatedOn,
                    Creator = m.Creator.FirstName + ' ' + m.Creator.LastName,
                })
                .FirstOrDefaultAsync();
        }
    }
}
