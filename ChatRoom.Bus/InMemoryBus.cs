using ChatRoom.Domain.Commands;
using ChatRoom.Domain.Interfaces.Bus;
using MediatR;

namespace ChatRoom.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<CommandResult> SendCommand<T>(T command) where T : ICommand<CommandResult>
        {
            return _mediator.Send(command);
        }
    }
}
