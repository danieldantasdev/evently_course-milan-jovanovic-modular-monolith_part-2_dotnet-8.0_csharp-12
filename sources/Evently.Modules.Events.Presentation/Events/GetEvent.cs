using Evently.Modules.Events.Application.UseCases.Events.Get;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Events;

internal static class GetEvent
{
    public static void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/events/{id}", async (Guid id, ISender sender) =>
        {
           GetEventQueryResponse getEventQuery = await sender.Send(new GetEventQuery(id));
            return getEventQuery is null ? Results.NotFound() : Results.Ok(getEventQuery);
        })
        .WithTags(Tags.Events);
    }
}
