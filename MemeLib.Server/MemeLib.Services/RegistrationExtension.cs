using MemeLib.Domain.Interfaces;
using MemeLib.Services.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MemeLib.Services;

public static class RegistrationExtension
{
    public static void RegisterDbServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IMigrationMonitor, MigrationMonitor>();
    }

    public static WebApplicationBuilder RegisterHostedServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHostedService<MigrationHostedService>();

        return builder;
    }
}