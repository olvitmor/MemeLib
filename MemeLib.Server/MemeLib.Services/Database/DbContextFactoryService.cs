using MemeLib.DbContext;
using MemeLib.Domain.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MemeLib.Services.Database;

public class DbContextFactoryService : IDbContextFactory<AppDbContext>
{
    private readonly PostgreSQLOptions _options;
    private readonly ILogger<DbContextFactoryService> _logger;
    
    public DbContextFactoryService(ILogger<DbContextFactoryService> logger, IOptions<PostgreSQLOptions> options)
    {
        _options = options.Value;
        _logger = logger;
    }


    public AppDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(_options.ConnectionString);
        optionsBuilder.LogTo(Console.WriteLine);
        return new AppDbContext(optionsBuilder.Options);
    }
}