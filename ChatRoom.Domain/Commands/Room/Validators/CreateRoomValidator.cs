using FluentValidation;

namespace ChatRoom.Domain.Commands.Room.Validators
{
    public class CreateRoomValidator : AbstractValidator<CreateRoomCommand>
    {
        public CreateRoomValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage(ValidationMessages.Required);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationMessages.Required);

            RuleFor(x => x.Name)
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLength);

            RuleFor(x => x.Descripition)
                .MaximumLength(280).WithMessage(ValidationMessages.MaxLength);
        }
    }
}
