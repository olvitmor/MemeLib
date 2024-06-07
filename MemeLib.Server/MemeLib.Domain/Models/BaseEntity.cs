using MemeLib.Domain.Interfaces;

namespace MemeLib.Domain.Models;

public abstract class BaseEntity : IHasId
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
}