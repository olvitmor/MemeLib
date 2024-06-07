using MemeLib.DbContext.Models;
using MemeLib.Domain.Interfaces.ReadEntity;
using MemeLib.Domain.Models;
using MemeLib.Domain.SearchParameters;
using MemeLib.Services.Repository;
using Microsoft.Extensions.Logging;

namespace MemeLib.Services.Memes;

internal class MemesReadService : IMemesReadService
{
    private readonly ILogger<MemesReadService> _logger;
    private readonly IRepositoryService _repository;

    public MemesReadService(ILogger<MemesReadService> logger, IRepositoryService repository)
    {
        _logger = logger;
        _repository = repository;
    }

    public async Task<MemeModel?> GetById(Guid entityId, CancellationToken token = default)
    {
        return await _repository.GetById<MemeDbModel>(entityId, token);
    }

    public Task<ICollection<MemeModel>> Find(MemeSearchParameters parameters, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}