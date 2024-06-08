using System.ComponentModel.DataAnnotations;
using MemeLib.Domain.Enums;
using MemeLib.Domain.Interfaces.CreateOrUpdateEntity;
using MemeLib.Domain.Interfaces.ReadEntity;
using MemeLib.Domain.Models;
using MemeLib.Domain.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MemeLib.Api.Controllers;

/// <summary>
/// Memes controller
/// </summary>
[Route("memes")]
public class MemesController : Controller
{
    private readonly ILogger<MemesController> _logger;
    private readonly IMemesReadService _readService;
    private readonly IMemesCreateOrUpdateService _createOrUpdateService;

    public MemesController(ILogger<MemesController> logger, IMemesReadService readService, IMemesCreateOrUpdateService createOrUpdateService)
    {
        _logger = logger;
        _readService = readService;
        _createOrUpdateService = createOrUpdateService;
    }

    /// <summary>
    /// Get meme by it's id
    /// </summary>
    /// <param name="memeId">Meme unique identifier</param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet("{memeId}")]
    [ProducesResponseType(typeof(MemeModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MemeModel>> GetMemeById([Required] Guid memeId, CancellationToken token = default)
    {
        var entity = await _readService.GetById(memeId, token);
        return entity is not null ? Ok(entity) : NotFound($"No such entity with '{memeId}' id");
    }

    /// <summary>
    /// Create or update meme
    /// </summary>
    /// <param name="memeId">Unique meme Id</param>
    /// <param name="request">Meme parameters request</param>
    /// <param name="token"></param>
    /// <returns>Meme entity</returns>
    [HttpPut("{memeId}")]
    [ProducesResponseType(typeof(MemeModel), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(MemeModel), StatusCodes.Status201Created)]
    public async Task<ActionResult<MemeModel>> CreateOrUpdateMeme([Required, FromRoute] Guid memeId,
        [FromBody] CreateOrUpdateMemeRequest request,
        CancellationToken token = default)
    {
        var (entity, actionResult) = await _createOrUpdateService.CreateOrUpdate(memeId, request, token);
        return actionResult is CreateOrUpdateResult.Created
            ? CreatedAtAction(nameof(CreateOrUpdateMeme), entity)
            : Ok(entity);
    }
}