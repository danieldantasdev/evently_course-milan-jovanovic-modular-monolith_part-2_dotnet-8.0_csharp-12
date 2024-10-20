using Evently.Modules.Events.Application.Abstractions.Data;
using Evently.Modules.Events.Domain.Entities.Events;
using Evently.Modules.Events.Domain.Repositories.Interfaces.Events;
using MediatR;

namespace Evently.Modules.Events.Application.UseCases.Events.Create;

internal sealed class CreateEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateEventCommand, Guid>
{
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = Event.Create(request.Title, request.Description, request.Location, request.StartsAtUtc, request.EndsAtUtc);
        eventRepository.Insert(@event);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return @event.Id;
    }
}
