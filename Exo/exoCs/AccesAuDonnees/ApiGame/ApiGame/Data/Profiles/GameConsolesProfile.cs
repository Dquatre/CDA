using ApiGame.Data.Dtos;
using ApiGame.Data.Models;
using AutoMapper;

namespace ApiGame.Data.Profiles
{
    public class GameConsolesProfile : Profile
    {
        public GameConsolesProfile() 
        {
            CreateMap<GameConsole, GameConsolesDTOFull>();
            CreateMap<GameConsolesDTOFull, GameConsole>();
            CreateMap<GameConsole,GameConsolesDTO>();
            CreateMap<GameConsolesDTO, GameConsole>();
        }
    }
}
