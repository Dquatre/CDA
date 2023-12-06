using AutoMapper;
using CrudModelControl.Models.Data;
using CrudModelControl.Models.Dtos;

namespace CrudModelControl.Models.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile() 
        {
            CreateMap <Product,ProductDtoOut>();
            CreateMap <ProductDtoOut, Product>();
            CreateMap<Product, ProductDtoFull>();
            CreateMap<ProductDtoFull, Product>();
        }
    }
}
