using System;
using FluentValidation;

namespace DigitalOwl.Api.Model
{
    public class CreatePoll
    {
        public string Title { get; set; }
        public DateTime? TimeLimit { get; set; }
    }

    public class ValidatePoll : AbstractValidator<CreatePoll>
    {
        public ValidatePoll()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}