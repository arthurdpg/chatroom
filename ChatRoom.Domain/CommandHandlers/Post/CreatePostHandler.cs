using ChatRoom.Domain.Commands;
using ChatRoom.Domain.Commands.Post;
using ChatRoom.Domain.Interfaces;

namespace ChatRoom.Domain.CommandHandlers.Post
{
    public class CreatePostHandler : IHandler<CreatePostCommand, CommandResult>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Models.Post> _repository;

        public CreatePostHandler(IUnitOfWork uow, IRepository<Models.Post> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task<CommandResult> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return CommandResultFactory.ValidationErrorResult(request);

            var post = new Models.Post(Guid.NewGuid(), request.UserId, request.RoomId, DateTime.Now, request.Content);

            await _repository.InsertAsync(post);
            await _uow.CommitAsync();

            return CommandResultFactory.SuccessResult(Messages.Sucess);
        }
    }
}
