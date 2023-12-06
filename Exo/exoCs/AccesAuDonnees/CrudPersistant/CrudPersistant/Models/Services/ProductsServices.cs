using CrudPersistant.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudPersistant.Models.Services
{
    public class ProductsServices
    {
        public ProductDbContext Context { get; set; }
        public ProductsServices()
        {
            Context = new ProductDbContext();
        }

        public void AddProducts(Product p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            Context.Products.Add(p);
            Context.SaveChanges();
        }

        public void DeleteProduct(Product p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            Context.Products.Remove(p);
            Context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return Context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return Context.Products.FirstOrDefault(p => p.IdProduct == id);
        }

        public void UpdateProduct(Product p)
        {
            Context.SaveChanges();
        }

    }
}
