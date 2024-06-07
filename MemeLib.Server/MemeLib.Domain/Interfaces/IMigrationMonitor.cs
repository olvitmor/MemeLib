namespace MemeLib.Domain.Interfaces;

public interface IMigrationMonitor
{
    public Task Migrate(CancellationToken token = default);
}