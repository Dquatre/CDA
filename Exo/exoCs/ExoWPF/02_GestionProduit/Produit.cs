using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_GestionProduit
{
    internal class Produit
    {
        public int IdProduit { get; set; }
        public string LibelleProduit { get; set; }
        public string Categories { get; set; }
        public string Rayons { get; set; }

        public Produit(int idProduit, string libelleProduit, string categories, string rayons)
        {
            IdProduit = idProduit;
            LibelleProduit = libelleProduit;
            Categories = categories;
            Rayons = rayons;
        }
    }
}
