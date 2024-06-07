using System.Linq.Expressions;
using MemeLib.Domain.Interfaces;

namespace MemeLib.Services.Repository;

internal interface IRepositoryService
{
    public Task<T?> GetById<T>(Guid entityId, CancellationToken token = default)
        where T : class, IHasId;

    public Task<ICollection<T>> Find<T>(Expression<Func<T, bool>> filter, CancellationToken token = default)
        where T : class;

    public Task<T> CreateOrUpdate<T>(T entity, bool? isNew, CancellationToken token = default)
        where T : class, IHasId;

    public Task<Guid> Delete<T>(Guid entityId, CancellationToken token = default)
        where T : class, IHasId;
}