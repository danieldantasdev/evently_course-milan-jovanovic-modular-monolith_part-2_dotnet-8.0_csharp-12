using Evently.Modules.Events.Application.UseCases.Events.Create;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Events;

internal static class CreateEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("events", async (Request request, ISender sender) =>
        {
            CreateEventCommand command = new (
                request.Title,
                request.Description,
                request.Location,
                request.StartsAtUtc,
                request.EndsAtUtc
            );
            Guid eventId = await sender.Send(command);
            return Results.Ok(eventId);
        })
        .WithTags(Tags.Events);
    }

    internal sealed class Request
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartsAtUtc { get; set; }
        public DateTime? EndsAtUtc { get; set; }
    }
}
