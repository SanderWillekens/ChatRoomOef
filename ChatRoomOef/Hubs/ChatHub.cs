using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomOef.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string message,string user)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
