using System;
using System.Data;
using System.Transactions;
using FluentValidation;

namespace Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<EventCreateVm>
    {
        public CreateEventCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} is required");

            RuleFor(e => e.Date)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(e => e.Price)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(0);
        }
    }
}