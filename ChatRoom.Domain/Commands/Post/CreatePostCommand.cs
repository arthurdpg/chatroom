using ChatRoom.Domain.Commands.Post.Validators;

namespace ChatRoom.Domain.Commands.Post
{
    public class CreatePostCommand : Command, ICommand<CommandResult>
    {
        public string UserId { get; set; }
        public Guid RoomId { get; set; }
        public string Content { get; set; }
        public CreatePostCommand(string userId, Guid roomId, string content)
        {
            UserId = userId;
            RoomId = roomId;
            Content = content;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreatePostValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
