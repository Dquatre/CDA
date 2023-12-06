using AutoMapper;
using Crud_Multipage.Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Multipage.Models.Profiles
{
    public class ProductsProfile : Profile
    {
        public static List<Product> FromObjectToProducts(List<Object> liste)
        {
            string listeSerialize = JsonConvert.SerializeObject(liste);
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(listeSerialize);
            return products;
        }
        public static List<Object> FromProductsToObject(List<Product> liste)
        {
            string listeSerialize = JsonConvert.SerializeObject(liste);
            List<Object> objs = JsonConvert.DeserializeObject<List<Object>>(listeSerialize);
            return objs;
        }
    }
}
