using Microsoft.AspNetCore.SignalR;

namespace ChatApp.SignalR
{
    public sealed class ChatHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("RecivedMessage", $"{Context.ConnectionId}", $"{message}");
        }
    }
}
