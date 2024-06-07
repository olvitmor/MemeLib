using MemeLib.Domain.Interfaces;
using MemeLib.Domain.Interfaces.ReadEntity;
using MemeLib.Services.Database;
using MemeLib.Services.Memes;
using MemeLib.Services.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MemeLib.Services;

public static class RegistrationExtension
{
    public static void RegisterDbServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IMigrationMonitor, MigrationMonitor>();
    }

    public static WebApplicationBuilder RegisterRepositoryServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IRepositoryService, RepositoryService>();

        builder.Services.AddScoped<IMemesReadService, MemesReadService>();

        return builder;
    }

    public static WebApplicationBuilder RegisterHostedServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddHostedService<MigrationHostedService>();

        return builder;
    }
}