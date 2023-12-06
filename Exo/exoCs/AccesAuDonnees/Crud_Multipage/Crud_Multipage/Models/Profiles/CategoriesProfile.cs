using Crud_Multipage.Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Multipage.Models.Profiles
{
    public class CategoriesProfile
    {
        public static List<Categorie> FromObjectToCategories(List<Object> liste)
        {
            string listeSerialize = JsonConvert.SerializeObject(liste);
            List<Categorie> products = JsonConvert.DeserializeObject<List<Categorie>>(listeSerialize);
            return products;
        }
        public static List<Object> FromCategoriesToObject(List<Categorie> liste)
        {
            string listeSerialize = JsonConvert.SerializeObject(liste);
            List<Object> objs = JsonConvert.DeserializeObject<List<Object>>(listeSerialize);
            return objs;
        }
    }
}
