using Evently.Modules.Events.Application.Abstractions.Data;
using Evently.Modules.Events.Domain.Entities.Events;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Infrastructure.Database;

public sealed class EventsDatabaseContext(DbContextOptions<EventsDatabaseContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Event> Events { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);
    }
}
