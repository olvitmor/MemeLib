using MemeLib.Domain.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MemeLib.StartUp.Modules;

public static class OptionsModule
{
    public static WebApplicationBuilder UseOptions(this WebApplicationBuilder builder)
    {
        builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);

        if (builder.Environment.IsDevelopment())
        {
            builder.Configuration.AddJsonFile("appsettings.Development.json", optional: false, reloadOnChange: false);   
        }

        builder.Services.Configure<PostgreSQLOptions>(builder.Configuration.GetSection(PostgreSQLOptions.OptionsKey));
        
        return builder;
    }
}