using MemeLib.Domain.Models;
using MemeLib.Domain.SearchParameters;

namespace MemeLib.Domain.Interfaces.ReadEntity;

public interface IMemesReadService : IEntityReadService<MemeModel, MemeSearchParameters>
{
    
}