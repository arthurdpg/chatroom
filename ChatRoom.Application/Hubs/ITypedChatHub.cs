namespace ChatRoom.Application.Hubs
{
    public interface ITypedChatHub
    {
        Task ReceiveMessage();
    }
}
