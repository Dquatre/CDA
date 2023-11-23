using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud
{
    public class Produit
    {
        public int IdProduit { get; set; }
        public string Name { get; set; }
        public Double Prix { get; set; }
        public String Categorie { get; set; }
        public int Stock { get; set;}

        public Produit(int idProduit, string name, double prix, string categorie, int stock)
        {
            IdProduit = idProduit;
            Name = name;
            Prix = prix;
            Categorie = categorie;
            Stock = stock;
        }
    }
}
