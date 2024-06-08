using System.Linq.Expressions;
using AutoMapper;
using MemeLib.DbContext;
using MemeLib.Domain.Enums;
using MemeLib.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MemeLib.Services.Repository;

internal class RepositoryService : IRepositoryService
{
    private readonly ILogger<RepositoryService> _logger;
    private readonly IAppDbContextFactory _dbContextFactory;
    private readonly IMapper _mapper;

    public RepositoryService(ILogger<RepositoryService> logger, IAppDbContextFactory dbContextFactory, IMapper mapper)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
        _mapper = mapper;
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

    public async Task<(T, CreateOrUpdateResult)> CreateOrUpdate<T>(Guid entityId, T entity, CancellationToken token = default,
        Action<T>? actionOnUpdate = null, Action<T>? actionOnCreate = null) 
        where T : class, IHasId
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(token);

        var entityInDb = await dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == entityId, token);
        var actionResult = CreateOrUpdateResult.Created;

        if (entityInDb != null)
        {
            entityInDb = (T)_mapper.Map(entity, entityInDb, typeof(T), typeof(T));
            actionOnUpdate?.Invoke(entityInDb);
            actionResult = CreateOrUpdateResult.Updated;
        }
        else
        {
            entityInDb = (T)_mapper.Map(entity, typeof(T), typeof(T));
            actionOnCreate?.Invoke(entityInDb);
            await dbContext.Set<T>().AddAsync(entityInDb, token);
        }
        
        await dbContext.SaveChangesAsync(token);
        return (entityInDb, actionResult);
    }

    public Task<Guid> Delete<T>(Guid entityId, CancellationToken token = default) where T : class, IHasId
    {
        throw new NotImplementedException();
    }
}