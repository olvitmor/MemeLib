using MemeLib.Domain.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MemeLib.Services.Database;

internal class MigrationHostedService : IHostedService
{
    private readonly ILogger<MigrationHostedService> _logger;
    private readonly IMigrationMonitor _migrationMonitor;

    public MigrationHostedService(ILogger<MigrationHostedService> logger, IMigrationMonitor migrationMonitor)
    {
        _logger = logger;
        _migrationMonitor = migrationMonitor;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await _migrationMonitor.Migrate(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}