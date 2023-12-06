using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud_Multipage.Models.Data
{
    public class Product
    {
        public int IdProduct { get; set; }

        public string NameProduct { get; set; } = null!;

        public double Price { get; set; }

        public int Quantity { get; set; }
        public int IdCategorie { get; set; }

        public Product(int idProduct, string nameProduct, double price, int quantity, int idCategorie)
        {
            IdProduct = idProduct;
            NameProduct = nameProduct;
            Price = price;
            Quantity = quantity;
            IdCategorie = idCategorie;
        }

        public Product()
        {
        }
    }
}
