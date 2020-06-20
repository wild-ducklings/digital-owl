using FluentValidation;

namespace DigitalOwl.Api.Model
{
    public class CreateGroupMessage
    {
        public string Content { get; set; }
    }

    public class ValidateGroupMessage : AbstractValidator<CreateGroupMessage>
    {
        public ValidateGroupMessage()
        {
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}