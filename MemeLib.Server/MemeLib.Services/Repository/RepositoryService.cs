using System.Linq.Expressions;
using MemeLib.DbContext;
using MemeLib.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MemeLib.Services.Repository;

public class RepositoryService : IRepositoryService
{
    private readonly ILogger<RepositoryService> _logger;
    private readonly IAppDbContextFactory _dbContextFactory;

    public RepositoryService(ILogger<RepositoryService> logger, IAppDbContextFactory dbContextFactory)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
    }

    public async Task<T?> GetById<T>(Guid entityId, CancellationToken token = default) 
        where T : class, IHasId
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(token);
        return await dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == entityId, token);
    }

    public Task<ICollection<T>> Find<T>(Expression<Func<T, bool>> filter, CancellationToken token = default) where T : class
    {
        throw new NotImplementedException();
    }

    public Task<T> CreateOrUpdate<T>(T entity, bool? isNew, CancellationToken token = default) where T : class, IHasId
    {
        throw new NotImplementedException();
    }

    public Task<Guid> Delete<T>(Guid entityId, CancellationToken token = default) where T : class, IHasId
    {
        throw new NotImplementedException();
    }
}