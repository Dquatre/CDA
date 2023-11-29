using ApiMinetesme.Data.Dtos;
using ApiMinetesme.Data.Models;
using AutoMapper;

namespace ApiMinetesme.Data.Profiles
{
    public class PantalonsProfiles :Profile
    {
        public PantalonsProfiles()
        {
            CreateMap<Pantalon, PantalonsDTO>();
            CreateMap<PantalonsDTO, Pantalon>();
        }
    }
}
