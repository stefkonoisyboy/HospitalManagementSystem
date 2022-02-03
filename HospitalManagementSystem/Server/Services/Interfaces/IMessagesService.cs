using HospitalManagementSystem.Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IMessagesService
    {
        Task CreateAsync(CreateMessageInputModel input);

        Task CreateReplyAsync(CreateReplyInputModel input);

        Task MarkAsSeenAsync(int id, MarkMessageAsSeenInputModel input);

        Task DeleteAsync(IEnumerable<int> messages);

        Task DeleteByIdAsync(int id);

        int GetAllUnseenMessagesCount(string userId);

        Task<ReceivedMessageByIdViewModel> GetReceivedMessageByIdAsync(int id);

        Task<CreatedMessageByIdViewModel> GetCreatedMessageByIdAsync(int id);

        Task<IEnumerable<AllMessagesByUserIdViewModel>> GetAllMessagesByReceiverIdAsync(string receiverId);

        Task<IEnumerable<AllMessagesByUserIdViewModel>> GetAllMessagesByCreatorIdAsync(string creatorId);

        Task<IEnumerable<AllUnseenMessagesViewModel>> GetAllUnseenMessages(string userId);
    }
}
