using ChatRoom.Domain.Commands;

namespace ChatRoom.Domain.Interfaces.Bus
{
    public interface IMediatorHandler
    {
        Task<CommandResult> SendCommand<T>(T command) where T : ICommand<CommandResult>;
    }
}
