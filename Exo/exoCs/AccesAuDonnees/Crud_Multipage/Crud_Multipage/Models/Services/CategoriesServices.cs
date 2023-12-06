using Crud_Multipage.Dao;
using Crud_Multipage.Models.Data;
using Crud_Multipage.Models.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Multipage.Models.Services
{
    public class CategoriesServices
    {
        static public string Path { get; set; } = "../../../Cat.json";
        static public List<Categorie> GetAllProducts()
        {
            StructureJson sj = GestionJson.LireFichierJson(Path);
            List<Categorie> liste = CategoriesProfile.FromObjectToCategories(sj.Liste);
            return liste;
        }
        static public Categorie GetById(int idCategorie)
        {
            List<Categorie> liste = GetAllProducts();
            Categorie p = liste.Find(r => r.IdCategorie == idCategorie);
            return p;
        }
    }
}
