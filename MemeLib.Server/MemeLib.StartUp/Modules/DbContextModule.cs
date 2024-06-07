using MemeLib.DbContext;
using MemeLib.Services;
using MemeLib.Services.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MemeLib.StartUp.Modules;

public static class DbContextModule
{
    public static WebApplicationBuilder UseDbContextModule(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContextFactory<AppDbContext, DbContextFactoryService>();
        builder.RegisterDbServices();

        return builder;
    }
}