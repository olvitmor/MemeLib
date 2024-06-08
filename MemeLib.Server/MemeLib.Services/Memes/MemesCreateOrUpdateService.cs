using AutoMapper;
using MemeLib.DbContext.Models;
using MemeLib.Domain.Enums;
using MemeLib.Domain.Interfaces;
using MemeLib.Domain.Interfaces.CreateOrUpdateEntity;
using MemeLib.Domain.Models;
using MemeLib.Domain.Requests;
using MemeLib.Services.Repository;
using Microsoft.Extensions.Logging;

namespace MemeLib.Services.Memes;

internal class MemesCreateOrUpdateService : IMemesCreateOrUpdateService
{
    private readonly ILogger<MemesCreateOrUpdateService> _logger;
    private readonly IRepositoryService _repository;
    private readonly IMapper _mapper;

    public MemesCreateOrUpdateService(ILogger<MemesCreateOrUpdateService> logger, IRepositoryService repository, IMapper mapper)
    {
        _logger = logger;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<(MemeModel?, CreateOrUpdateResult)> CreateOrUpdate(Guid entityId, CreateOrUpdateMemeRequest request, CancellationToken token)
    {
        var timestamp = DateTime.UtcNow;

        var onCreate = (MemeDbModel entity) =>
        {
            entity.Ts = timestamp;
            entity.PublishDate = DateOnly.FromDateTime(timestamp);
        };

        var onUpdate = (MemeDbModel entity) =>
        {
            entity.Ts = timestamp;
        };
        
        var (memeDbModel, actionResult) = await _repository.CreateOrUpdate<MemeDbModel>(entityId, _mapper.Map<MemeDbModel>(request), token, onCreate, onUpdate);
        return (_mapper.Map<MemeModel>(memeDbModel), actionResult);
    }
}