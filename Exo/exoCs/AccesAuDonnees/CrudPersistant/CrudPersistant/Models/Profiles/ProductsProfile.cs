using AutoMapper;
using CrudPersistant.Models.Data;
using CrudPersistant.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudPersistant.Models.Profiles
{
    internal class ProductsProfile : Profile
    {
        public ProductsProfile() 
        { 
            CreateMap<Product, ProductDtoOut>();
            CreateMap<ProductDtoOut, Product>();
        }
    }
}
