using ApiPersonne.Data.Dtos;
using ApiPersonne.Data.Models;
using AutoMapper;

namespace ApiPersonne.Data.Profiles
{
    public class PersonnesProfiles : Profile
    {
        public PersonnesProfiles()
        {
            CreateMap<Personne, PersonnesDTO>();
            CreateMap<PersonnesDTO, Personne>();
        }
    }
}
