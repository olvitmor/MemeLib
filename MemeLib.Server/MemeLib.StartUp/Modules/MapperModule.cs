using MemeLib.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MemeLib.StartUp.Modules;

public static class MapperModule
{
    public static WebApplicationBuilder UseMapperModule(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        return builder;
    }
}