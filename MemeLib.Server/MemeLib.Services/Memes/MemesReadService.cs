using AutoMapper;
using MemeLib.DbContext.Models;
using MemeLib.Domain.Interfaces;
using MemeLib.Domain.Interfaces.ReadEntity;
using MemeLib.Domain.Models;
using MemeLib.Domain.SearchParameters;
using Microsoft.Extensions.Logging;

namespace MemeLib.Services.Memes;

internal class MemesReadService : IMemesReadService
{
    private readonly ILogger<MemesReadService> _logger;
    private readonly IRepositoryService _repository;
    private readonly IMapper _mapper;

    public MemesReadService(ILogger<MemesReadService> logger, IRepositoryService repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<MemeModel?> GetById(Guid entityId, CancellationToken token = default)
    {
        var entity = await _repository.GetById<MemeDbModel>(entityId, token);
        return _mapper.Map<MemeModel>(entity);
    }

    public Task<ICollection<MemeModel>> Find(MemeSearchParameters parameters, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}