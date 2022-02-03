using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.Messages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    public class MessagesController : ApiController
    {
        private readonly IMessagesService messagesService;
        private readonly IUsersService usersService;

        public MessagesController(IMessagesService messagesService, IUsersService usersService)
        {
            this.messagesService = messagesService;
            this.usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllMessagesByUserIdViewModel>>> GetAllByCreatorId()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<AllMessagesByUserIdViewModel> viewModel = await this.messagesService.GetAllMessagesByCreatorIdAsync(userId);
            return this.Ok(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllMessagesByUserIdViewModel>>> GetAllByReceiverId()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            IEnumerable<AllMessagesByUserIdViewModel> viewModel = await this.messagesService.GetAllMessagesByReceiverIdAsync(userId);
            return this.Ok(viewModel);
        }

        [HttpGet]
        public ActionResult<int> GetUnseenMessagesCount()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return this.Ok(this.messagesService.GetAllUnseenMessagesCount(userId)); 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllUnseenMessagesViewModel>>> GetUnseenMessages()
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return this.Ok(await this.messagesService.GetAllUnseenMessages(userId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReceivedMessageByIdViewModel>> GetReceivedMessageById(int id)
        {
            ReceivedMessageByIdViewModel viewModel = await this.messagesService.GetReceivedMessageByIdAsync(id);
            return this.Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CreatedMessageByIdViewModel>> GetCreatedMessageById(int id)
        {
            CreatedMessageByIdViewModel viewModel = await this.messagesService.GetCreatedMessageByIdAsync(id);
            return this.Ok(viewModel);
        }

        [HttpGet]
        public async Task<ActionResult<CreateMessageInputModel>> Create()
        {
            CreateMessageInputModel input = new CreateMessageInputModel
            {
                Users = await this.usersService.GetAllUsersForDropDown(),
            };

            return this.Ok(input);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMessageInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Users = await this.usersService.GetAllUsersForDropDown();
                return this.BadRequest(input);
            }

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            input.CreatorId = userId;
            await this.messagesService.CreateAsync(input);

            return this.Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReply(CreateReplyInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(input);
            }

            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            input.CreatorId = userId;
            await this.messagesService.CreateReplyAsync(input);

            return this.Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> MarkAsSeen(int id, MarkMessageAsSeenInputModel input)
        {
            await this.messagesService.MarkAsSeenAsync(id, input);
            return this.Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery(Name = "ids")] int[] ids)
        {
            await this.messagesService.DeleteAsync(ids);
            return this.Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await this.messagesService.DeleteByIdAsync(id);
            return this.Ok();
        }
    }
}
