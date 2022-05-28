using FluentValidation;

namespace ChatRoom.Domain.Commands.Post.Validators
{
    public class CreateCommandPostValidator : AbstractValidator<CreateCommandPostCommand>
    {
        public CreateCommandPostValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage(ValidationMessages.Required);

            RuleFor(x => x.UserId)
                 .MaximumLength(255).WithMessage(ValidationMessages.MaxLength);

            RuleFor(x => x.RoomId)
                .NotEmpty().WithMessage(ValidationMessages.Required);

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage(ValidationMessages.Required);

            RuleFor(x => x.Content)
                .MaximumLength(280).WithMessage(ValidationMessages.MaxLength);

            RuleFor(x => x.Content)
                .Matches(@"^\/[a-zA-Z0-9]+=\S+$");

            RuleFor(x => x.ChatHub)
                .NotNull().WithMessage(ValidationMessages.Required);
        }
    }
}
