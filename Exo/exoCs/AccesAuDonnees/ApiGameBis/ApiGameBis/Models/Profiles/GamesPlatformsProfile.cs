using ApiGameBis.Models.Data;
using ApiGameBis.Models.Dtos;
using AutoMapper;

namespace ApiGameBis.Models.Profiles
{
    public class GamesPlatformsProfile : Profile
    {
        public GamesPlatformsProfile()
        {
            CreateMap<GamesPlatform, PlatformsDtoLink>()
                .ForMember(pDto => pDto.PlatformName, option => option.MapFrom(gp => gp.GamePlatform.PlatformName))
                .ForMember(pDto => pDto.Constructor, option => option.MapFrom(gp => gp.GamePlatform.Constructor));
            CreateMap<GamesPlatform, GamesPlatformsDtoWithPlatformGame>();
            CreateMap<GamesPlatformsDtoWithPlatformGame, GamesPlatform>();
            CreateMap<GamesPlatform, GamesPlatformsDto>();
            CreateMap<GamesPlatformsDto, GamesPlatform>();

        }
    }
}
