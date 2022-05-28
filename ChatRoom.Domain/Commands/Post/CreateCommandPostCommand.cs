using ChatRoom.Application.Hubs;
using ChatRoom.Domain.Commands.Post.Validators;
using Microsoft.AspNetCore.SignalR;

namespace ChatRoom.Domain.Commands.Post
{
    public class CreateCommandPostCommand : Command, ICommand<CommandResult>
    {
        public string UserId { get; set; }
        public Guid RoomId { get; set; }
        public string Content { get; set; }
        public IHubContext<ChatHub, ITypedChatHub> ChatHub { get; set; }
        public CreateCommandPostCommand(string userId, Guid roomId, string content, IHubContext<ChatHub, ITypedChatHub> hub)
        {
            UserId = userId;
            RoomId = roomId;
            Content = content;
            ChatHub = hub;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateCommandPostValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
