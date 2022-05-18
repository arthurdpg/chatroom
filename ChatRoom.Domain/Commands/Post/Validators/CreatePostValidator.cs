using FluentValidation;

namespace ChatRoom.Domain.Commands.Post.Validators
{
    public class CreatePostValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage(ValidationMessages.Required);

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage(ValidationMessages.Required);

            RuleFor(x => x.Content)
                .NotEmpty().WithMessage(ValidationMessages.Required);

            RuleFor(x => x.Content)
                .MaximumLength(280).WithMessage(ValidationMessages.MaxLength);
        }
    }
}
