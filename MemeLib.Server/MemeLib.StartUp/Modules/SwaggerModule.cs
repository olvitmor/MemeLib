using Microsoft.AspNetCore.Builder;

namespace MemeLib.StartUp.Modules;

public static class SwaggerModule
{
    public static WebApplication UseSwaggerModule(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options => { options.RoutePrefix = "swagger"; });
        
        return app;
    }
}