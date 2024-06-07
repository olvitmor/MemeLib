using System.ComponentModel.DataAnnotations;
using MemeLib.Domain.Interfaces.ReadEntity;
using MemeLib.Domain.Models;
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

    public MemesController(ILogger<MemesController> logger, IMemesReadService readService)
    {
        _logger = logger;
        _readService = readService;
    }

    /// <summary>
    /// Get meme by it's id
    /// </summary>
    /// <param name="memeId">Meme unique identifier</param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpGet("{memeId}")]
    [ProducesResponseType<MemeModel>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MemeModel>> GetMemeById([Required]Guid memeId, CancellationToken token)
    {
        var entity = await _readService.GetById(memeId, token);
        return entity is not null ? Ok(entity) : NotFound($"No such entity with '{memeId}' id");
    }
}