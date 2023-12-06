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
    public class ProductsServices
    {
        static public string Path { get; set; } = "../../../Prod.json";
        static public int NextId { get; set; }

        static public List<Product> GetAllProducts()
        {
            StructureJson sj = GestionJson.LireFichierJson(Path);
            List<Product> liste = ProductsProfile.FromObjectToProducts(sj.Liste);
            NextId = sj.NextId;

            return liste;
        }
        static public Product GetById(int idProduct)
        {
            List<Product> liste = GetAllProducts();
            Product p = liste.Find(r => r.IdProduct == idProduct);
            return p;
        }

        static public void SaveProducts(List<Product> liste)
        {
            StructureJson sj = new StructureJson();
            sj.Liste = ProductsProfile.FromProductsToObject(liste);
            sj.NextId = NextId;
            GestionJson.EcrireFichierJson(sj, Path); 
        }

        static public void AddProduct(Product p)
        {
            List<Product> liste = GetAllProducts();
            p.IdProduct = NextId++;
            liste.Add(p);
            SaveProducts(liste);
        }
        static public void UpdateProduct(Product p)
        {
            List<Product> liste = GetAllProducts();
            int position = liste.FindIndex(r => r.IdProduct == p.IdProduct);
            liste[position].NameProduct = p.NameProduct;
            liste[position].Price = p.Price;
            liste[position].Quantity = p.Quantity;
            SaveProducts(liste);
        }
        static public void DeleteProduct(Product p)
        {
            List<Product> liste = GetAllProducts();
            liste.RemoveAll(x => x.IdProduct == p.IdProduct);
            SaveProducts(liste);
        }
    }
}
