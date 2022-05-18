using ChatRoom.Domain.Commands;
using MediatR;

namespace ChatRoom.Domain.CommandHandlers
{
    public interface IHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
        where TResult : CommandResult
    {

    }
}
