using System.Reflection.Metadata;
using Evently.Modules.Events.Application.Abstractions.Data;
using Evently.Modules.Events.Domain.Repositories.Interfaces.Events;
using Evently.Modules.Events.Infrastructure.Data;
using Evently.Modules.Events.Infrastructure.Database;
using Evently.Modules.Events.Infrastructure.Repositories.Events;
using Evently.Modules.Events.Presentation.Events;
using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql;

namespace Evently.Modules.Events.Infrastructure;

public static class EventsModule
{
    public static void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        EventEndpoint.MapEndpoints(endpoints);
    }
    
    public static IServiceCollection AddEventsModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly);
        });
        
        services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly, includeInternalTypes: true);
        
        services.AddInfrastructure(configuration);
        
        return services;
    }
    
    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string databaseConnectionString = configuration.GetConnectionString("Database")!;
        NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(databaseConnectionString).Build();
        services.TryAddSingleton(dataSource);
        services.AddScoped<IDatabaseConnectionFactory, DatabaseConnectionFactory>();
        
        services.AddDbContext<EventsDatabaseContext>(options => 
            options.UseNpgsql(databaseConnectionString, npgsqloptions => 
                    npgsqloptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events)
                )
                .UseSnakeCaseNamingConvention()
        );
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventsDatabaseContext>());
    }
}
