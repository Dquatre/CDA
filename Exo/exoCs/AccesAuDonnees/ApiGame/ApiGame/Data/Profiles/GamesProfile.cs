using ApiGame.Data.Dtos;
using ApiGame.Data.Models;
using AutoMapper;

namespace ApiGame.Data.Profiles
{
    public class GamesProfile : Profile
    {
        public GamesProfile()
        {
            CreateMap<Game, GamesDTOFull>();
            CreateMap<GamesDTOFull, Game>();
            CreateMap<Game, GamesDTO>().ForMember(gDto => gDto.GameConsoleName , action => action.MapFrom(g => g.IdGameConsoleNavigation.Nom));
            CreateMap<GamesDTO, Game>();

            
            
        }
        public static Game GameDtoToGame(GamesDTO gameDto, GameConsole gc)
        {
            Game gameToRepo = new Game();
            gameToRepo.Titre = gameDto.Titre;
            gameToRepo.SousTitre = gameDto.SousTitre;
            gameToRepo.AnneeSortie = gameDto.AnneeSortie;
            gameToRepo.IdGameConsole = gc.IdGameConsole;
            return gameToRepo;
        }
    }
}
