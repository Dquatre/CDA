using ApiGameBis.Models.Data;
using ApiGameBis.Models.Dtos;
using AutoMapper;

namespace ApiGameBis.Models.Profiles
{
    public class GamesPlatformsProfile : Profile
    {
        public GamesPlatformsProfile()
        {
            CreateMap<GamesPlatform, GamesPlatformsDto>();
            CreateMap<GamesPlatformsDto, GamesPlatform>();
        }
    }
}
