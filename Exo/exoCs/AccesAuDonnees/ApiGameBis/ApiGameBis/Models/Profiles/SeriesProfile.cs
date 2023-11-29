using ApiGameBis.Models.Data;
using ApiGameBis.Models.Dtos;
using AutoMapper;

namespace ApiGameBis.Models.Profiles
{
    public class SeriesProfile : Profile
    {
        public SeriesProfile() 
        {
            CreateMap<Serie, SeriesDtoWithListGame>();
            CreateMap<SeriesDtoWithListGame, Serie>();
            CreateMap<Serie, SeriesDto>();
            CreateMap<SeriesDto, Serie>();
        }
    }
}
