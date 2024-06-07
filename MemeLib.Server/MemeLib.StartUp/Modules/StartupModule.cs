using MemeLib.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MemeLib.StartUp.Modules;

public static class StartupModule
{
    public static WebApplicationBuilder UseStartupModule(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddControllers()
            .AddNewtonsoftJson()
            .AddApplicationPart(typeof(ApiModule).Assembly);

        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(o =>
            {
                o.EnableAnnotations();
                var xmlFilename = $"{typeof(ApiModule).Assembly.GetName().Name}.xml";
                o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

        return builder;
    }
}