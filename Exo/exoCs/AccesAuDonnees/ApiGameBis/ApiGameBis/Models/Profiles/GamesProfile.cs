using ApiGameBis.Models.Data;
using ApiGameBis.Models.Dtos;
using AutoMapper;
using System;

namespace ApiGameBis.Models.Profiles
{
    public class GamesProfile : Profile
    {
        public GamesProfile()
        {
            CreateMap<Game, GamesDtoFull>().ForMember(gDto => gDto.GameSerie, action => action.MapFrom(g => g.GameSerie.SerieName))
                .ForMember(gDto => gDto.ListPlatforms, action => action.MapFrom(g => g.ListGamesPlatforms));
            CreateMap<GamesDtoFull, Game>();
            CreateMap<Game, GamesDtoWithSerie>();
            CreateMap<GamesDtoWithSerie, Game>();
            CreateMap<Game, GamesDtoOut>();
            CreateMap<GamesDtoOut, Game>();
            CreateMap<Game, GamesDto>();
            CreateMap<GamesDto, Game>();
        }
        public static Game GameDtoToGame(GamesDtoOut gameDto, Serie serie)
        {
            Game gameToRepo = new Game();
            gameToRepo.Title = gameDto.Title;
            gameToRepo.SubTitle = gameDto.SubTitle;
            gameToRepo.ReleaseYear = gameDto.ReleaseYear;
            gameToRepo.IdSerie = serie.IdSerie;
            return gameToRepo;
        }
    }
}
