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
    public class ProductsProfile
    {
        public IEnumerable<ProductDtoOut> ListPocoToDto(List<Product> listProduit)
        {
            List<ProductDtoOut> listProdDto = new List<ProductDtoOut>();
            foreach (var item in listProduit)
            {
                listProdDto.Add(PocoToDto(item));
            }
            return listProdDto;
        }
        public ProductDtoOut PocoToDto(Product produit)
        {
            ProductDtoOut prodDto = new ProductDtoOut();
            prodDto.NameProduct = produit.NameProduct;
            prodDto.Quantity = produit.Quantity;
            prodDto.Price = produit.Price;
            prodDto.ReleaseDate = produit.ReleaseDate;
            return prodDto;
        }
    }
}
