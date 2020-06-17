using System;
using FluentValidation;

namespace DigitalOwl.Api.Model
{
    public class CreatePoll
    {
        /// <summary>
        /// Poll title.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Optional poll time limit.
        /// </summary>
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