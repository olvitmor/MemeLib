namespace MemeLib.Domain.Interfaces.ReadEntity;

public interface IEntityReadService<TEntity, in TSearchParameters>
{
    /// <summary>
    /// Get entity by it's id
    /// </summary>
    /// <param name="entityId">Entity id</param>
    /// <param name="token">Cancellation token</param>
    /// <returns>Entity if found</returns>
    public Task<TEntity?> GetById(Guid entityId, CancellationToken token = default);

    public Task<ICollection<TEntity>> Find(TSearchParameters parameters, CancellationToken token = default);
}