using Microsoft.AspNetCore.SignalR;

namespace ChatRoom.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, Guid roomId)
        {
            await Clients.Group(roomId.ToString()).SendAsync("ReceiveMessage", user, message);
        }

        public Task JoinRoom(Guid roomId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }

        public Task LeaveRoom(Guid roomId)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());
        }
    }
}
