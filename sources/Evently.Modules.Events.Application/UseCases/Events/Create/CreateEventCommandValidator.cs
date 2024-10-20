using FluentValidation;

namespace Evently.Modules.Events.Application.UseCases.Events.Create;

internal sealed class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Location).NotEmpty().MaximumLength(100);
        RuleFor(x => x.StartsAtUtc).NotEmpty();
        RuleFor(x => x.EndsAtUtc).GreaterThanOrEqualTo(x => x.StartsAtUtc).When(x => x.EndsAtUtc.HasValue);
    }
}
