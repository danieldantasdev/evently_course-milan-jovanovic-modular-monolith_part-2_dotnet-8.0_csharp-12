using Evently.Modules.Events.Api.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Api.Events;

public static class GetEvent
{
    public static void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/events/{id}", async (Guid id, EventsDatabaseContext context) =>
        {
            EventResponse? @event = await context.Events
                .Where(e => e.Id == id)
                .Select(e => new EventResponse(e.Id, e.Title, e.Description, e.Location, e.StartsAtUtc, e.EndsAtUtc, e.Status))
                .SingleOrDefaultAsync();
            
            return @event is null ? Results.NotFound() : Results.Ok(@event);
        })
        .WithTags(Tags.Events);
    }
}
