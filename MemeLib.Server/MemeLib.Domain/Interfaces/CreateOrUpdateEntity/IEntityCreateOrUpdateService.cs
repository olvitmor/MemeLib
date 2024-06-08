using MemeLib.Domain.Enums;

namespace MemeLib.Domain.Interfaces.CreateOrUpdateEntity;

public interface IEntityCreateOrUpdateService<TModel, in TCreateOrUpdateRequest>
    where TModel : class, IHasId
{
    public Task<(TModel?, CreateOrUpdateResult)> CreateOrUpdate(Guid entityId, TCreateOrUpdateRequest request,
        CancellationToken token);
}