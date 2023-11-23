using AutoMapper;
using CreerApi.Data.DTO;
using CreerApi.Data.Models;

namespace CreerApi.Data.Profiles
{
    public class PersonneProfile : Profile
    {
        public PersonneProfile()
        {
            CreateMap<Personne, PersonneDTO>();
            CreateMap<PersonneDTO, Personne>();
        }
    }
}
