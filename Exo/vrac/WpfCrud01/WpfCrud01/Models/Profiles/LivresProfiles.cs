using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCrud01.Models.Data;
using WpfCrud01.Models.Dtos;

namespace WpfCrud01.Models.Profiles
{
    public class LivresProfiles : Profile
    {
        public LivresProfiles() 
        {
            CreateMap<Livre, LivresDtoOut>();
            CreateMap<LivresDtoOut, Livre>();

        }

    }
}
