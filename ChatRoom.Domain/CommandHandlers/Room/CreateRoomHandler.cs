using ChatRoom.Domain.Commands;
using ChatRoom.Domain.Commands.Room;
using ChatRoom.Domain.Interfaces;

namespace ChatRoom.Domain.CommandHandlers.Room
{
    public class CreateRoomHandler : IHandler<CreateRoomCommand, CommandResult>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Models.Room> _repository;

        public CreateRoomHandler(IUnitOfWork uow, IRepository<Models.Room> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task<CommandResult> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return CommandResultFactory.ValidationErrorResult(request);

            var room = new Models.Room(Guid.NewGuid(), request.UserId, DateTime.Now, request.Name, request.Descripition);

            await _repository.InsertAsync(room);
            await _uow.CommitAsync();

            return CommandResultFactory.SuccessResult(Messages.Sucess);
        }
    }
}
