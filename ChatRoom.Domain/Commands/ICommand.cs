using MediatR;

namespace ChatRoom.Domain.Commands
{
    public interface ICommand<out TResult> : IRequest<TResult>
        where TResult : CommandResult
    {

    }
}
