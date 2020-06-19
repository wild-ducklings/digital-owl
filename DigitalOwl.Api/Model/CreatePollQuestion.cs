using System;
using FluentValidation;

namespace DigitalOwl.Api.Model
{
    public class CreatePollQuestion
    {
        public string QuestionContent { get; set; }
        public DateTime? TimeLimit { get; set; }
        public int? Points { get; set; }
    }

    public class ValidatePollQuestion : AbstractValidator<CreatePollQuestion>
    {
        public ValidatePollQuestion()
        {
            RuleFor(x => x.QuestionContent).NotEmpty();
            RuleFor(x => x.Points).GreaterThan(-1).LessThan(1000);
        }
    }
}