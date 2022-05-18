using ChatRoom.Domain.Commands.Room.Validators;

namespace ChatRoom.Domain.Commands.Room
{
    public class CreateRoomCommand : Command, ICommand<CommandResult>
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Descripition { get; set; }
        public CreateRoomCommand(string userId, string name, string descripition)
        {
            UserId = userId;
            Name = name;
            Descripition = descripition;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateRoomValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
