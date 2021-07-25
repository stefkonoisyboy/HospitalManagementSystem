using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Hubs
{
    public class OnlineHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            ConnectedUsers.Usernames.Add(Context.User.Identity.Name);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            ConnectedUsers.Usernames.Remove(Context.User.Identity.Name);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
