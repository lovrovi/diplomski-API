using AutoMapper;
using services.Models;
using services.Requests;
using services.Responses;

namespace services.Mapper;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Advertisement, AdvertisementResponse>();
        CreateMap<AdvertisementPostRequest, Advertisement>();
    }
}
