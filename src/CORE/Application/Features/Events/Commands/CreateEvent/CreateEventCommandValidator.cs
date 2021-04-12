using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Application.Contracts.Persistence;
using FluentValidation;

namespace Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<EventCreateVm>
    {
        private readonly IEventRepository _eventRepository;
        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
            
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} is required");

            RuleFor(e => e.Date)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name and data already exists");

            RuleFor(e => e.Price)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(0);
        }

        private async Task<bool> EventNameAndDateUnique(EventCreateVm e , CancellationToken cancellationToken)
        {
            return !( await _eventRepository.IsEventNameAndDateUnique(e.Name, e.Date) );
        }
    }
}