using MemeLib.Services;
using MemeLib.StartUp.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace MemeLib.StartUp;

internal static class Program
{
    private static void Main(string[] args)
    {
        var app = WebApplication
            .CreateBuilder(args)
            .UseStartupModule()
            .UseOptions()
            .UseDbContextModule()
            .RegisterRepositoryServices()
            .RegisterHostedServices()
            .Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwaggerModule();
        app.UseRouting();
        app.MapControllers();
        
        app.Run();
    }
}