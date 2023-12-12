using AutoMapper;
using GestionStock.Models.Data;
using GestionStock.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Models.Profiles
{
    public class CategoriesProfiles : Profile
    {
        public CategoriesProfiles() 
        {
            CreateMap<Category, CategoriesDtoOut>();
            CreateMap<CategoriesDtoOut, Category>();
        }
    }
}
