using ApiGameBis.Models.Data;
using ApiGameBis.Models.Dtos;
using AutoMapper;

namespace ApiGameBis.Models.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile() 
        {
            CreateMap<Platform, PlatformsDtoWithListGamesPlatforms>();
            CreateMap<PlatformsDtoWithListGamesPlatforms, Platform>();
            CreateMap<Platform, PlatformsDto>();
            CreateMap<PlatformsDto, Platform>();
        }
        
    }
}
