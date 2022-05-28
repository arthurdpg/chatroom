using ChatRoom.Domain.Commands;
using ChatRoom.Domain.Commands.Post;
using ChatRoom.Domain.Interfaces;
using ChatRoom.Domain.Interfaces.Bus;

namespace ChatRoom.Domain.CommandHandlers.Post
{
    public class CreatePostHandler : IHandler<CreatePostCommand, CommandResult>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Models.Post> _repository;
        IMediatorHandler _bus;

        public CreatePostHandler(IUnitOfWork uow, IRepository<Models.Post> repository, IMediatorHandler bus)
        {
            _uow = uow;
            _repository = repository;
            _bus = bus;
        }

        public async Task<CommandResult> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return CommandResultFactory.ValidationErrorResult(request);

            var post = new Models.Post(Guid.NewGuid(), request.UserId, null, request.RoomId, DateTime.Now, request.Content);
            
            await _repository.InsertAsync(post);
            await _uow.CommitAsync();

            if (post.IsCommand)
            {
                request.ChatHub.Clients.User(request.UserId).ReceiveMessage();
                _bus.SendCommand(new CreateCommandPostCommand(request.UserId, request.RoomId, request.Content, request.ChatHub));
                return CommandResultFactory.SuccessResult(Messages.Sucess);
            }
            else
            {
                request.ChatHub.Clients.Group(request.RoomId.ToString()).ReceiveMessage();
            }

            return CommandResultFactory.SuccessResult(Messages.Sucess);
        }
    }
}
