using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Events;

public static class EventEndpoint
{
    public static void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        CreateEvent.MapEndpoint(endpoints);
        GetEvent.MapEndpoints(endpoints);
    }
}
