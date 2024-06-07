using MemeLib.DbContext;
using MemeLib.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;

namespace MemeLib.Services.Database;

internal class MigrationMonitor : IMigrationMonitor
{
    private readonly ILogger<MigrationMonitor> _logger;
    private readonly IAppDbContextFactory _dbContextFactory;
    
    public MigrationMonitor(ILogger<MigrationMonitor> logger, IAppDbContextFactory dbContextFactory)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
    }

    public async Task Migrate(CancellationToken token = default)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(token);

        var migrator = dbContext.Database.GetService<IMigrator>();

        foreach (var migration in await dbContext.Database.GetPendingMigrationsAsync(token))
        {
            await migrator.MigrateAsync(migration, token);
        }
    }
}