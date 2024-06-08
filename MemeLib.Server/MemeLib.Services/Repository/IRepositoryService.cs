using System.Linq.Expressions;
using MemeLib.Domain.Enums;

namespace MemeLib.Domain.Interfaces;

internal interface IRepositoryService
{
    /// <summary>
    /// Get entity by id
    /// </summary>
    /// <param name="entityId">Entity id</param>
    /// <param name="token">Cancellation token</param>
    /// <typeparam name="T">Entity type</typeparam>
    /// <returns>Returns entity if found</returns>
    public Task<T?> GetById<T>(Guid entityId, CancellationToken token = default)
        where T : class, IHasId;

    public Task<ICollection<T>> Find<T>(Expression<Func<T, bool>> filter, CancellationToken token = default)
        where T : class;

    /// <summary>
    /// Create or update entity
    /// </summary>
    /// <param name="entity">Entity object</param>
    /// <param name="token">Cancellation token</param>
    /// <param name="actionOnUpdate">Action to execute before update</param>
    /// <param name="actionOnCreate">Action to execute before creation</param>
    /// <typeparam name="T">Entity type</typeparam>
    /// <returns>Returns (Entity object, Created or updated) tuple</returns>
    public Task<(T, CreateOrUpdateResult)> CreateOrUpdate<T>(Guid entityId, T entity, CancellationToken token = default,
        Action<T>? actionOnUpdate = null, Action<T>? actionOnCreate = null)
        where T : class, IHasId;

    public Task<Guid> Delete<T>(Guid entityId, CancellationToken token = default)
        where T : class, IHasId;
}