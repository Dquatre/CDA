using AutoMapper;
using CrudWithBdd.Models.Data;
using CrudWithBdd.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWithBdd.Models.Profiles
{
    public class SallesProfile : Profile
    {
        public SallesProfile() 
        {
            CreateMap<Salle, SallesDtoOut>();
            CreateMap<SallesDtoOut, Salle>();
        }
    }
}
