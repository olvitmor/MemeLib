using MemeLib.Domain.Models;
using MemeLib.Domain.Requests;

namespace MemeLib.Domain.Interfaces.CreateOrUpdateEntity;

public interface IMemesCreateOrUpdateService : IEntityCreateOrUpdateService<MemeModel, CreateOrUpdateMemeRequest>;