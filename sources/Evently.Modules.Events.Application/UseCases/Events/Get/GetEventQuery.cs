using MediatR;

namespace Evently.Modules.Events.Application.UseCases.Events.Get;

public sealed record GetEventQuery(Guid Id) : IRequest<GetEventQueryResponse>;
