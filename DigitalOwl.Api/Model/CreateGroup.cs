using FluentValidation;

namespace DigitalOwl.Api.Model
{
    public class CreateGroup
    {
        public string Name { get; set; }
    }

    public class ValidateGroup : AbstractValidator<CreateGroup>
    {
        public ValidateGroup()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}