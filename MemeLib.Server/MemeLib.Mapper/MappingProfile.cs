using AutoMapper;
using MemeLib.DbContext.Models;
using MemeLib.Domain.Models;
using MemeLib.Domain.Requests;

namespace MemeLib.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMemeMap();
    }

    private void CreateMemeMap()
    {
        CreateMap<CreateOrUpdateMemeRequest, MemeDbModel>();
        CreateMap<MemeDbModel, MemeModel>().ReverseMap();
    }
}