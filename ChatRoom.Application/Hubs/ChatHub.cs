using Microsoft.AspNetCore.SignalR;

namespace ChatRoom.Application.Hubs
{
    public class ChatHub : Hub<ITypedChatHub>
    {
        public async Task JoinRoom(Guid roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }

        public Task LeaveRoom(Guid roomId)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());
        }
    }
}
