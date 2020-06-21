using FluentValidation;

namespace DigitalOwl.Api.Model
{
    public class CreatePollAnswer
    {
        public string AnswerContent { get; set; }
        public bool? Correctness { get; set; }
    }
    
    public class ValidatePollAnswer : AbstractValidator<CreatePollAnswer>
    {
        public ValidatePollAnswer()
        {
            RuleFor(x => x.AnswerContent).NotEmpty();
        }
    }
}