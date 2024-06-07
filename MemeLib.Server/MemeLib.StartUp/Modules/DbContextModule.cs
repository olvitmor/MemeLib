using MemeLib.DbContext;
using MemeLib.Domain.Options;
using MemeLib.Services;
using MemeLib.Services.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MemeLib.StartUp.Modules;

public static class DbContextModule
{
    public static WebApplicationBuilder UseDbContextModule(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContextFactory<AppDbContext, DbContextFactoryService>();
        builder.Services.AddSingleton<IAppDbContextFactory, DbContextFactoryService>();
        builder.RegisterDbServices();

        return builder;
    }
}