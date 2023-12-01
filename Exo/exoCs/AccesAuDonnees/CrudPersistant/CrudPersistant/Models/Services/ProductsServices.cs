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

        private readonly ProductDbContext _context;
        public ProductsServices(ProductDbContext context)
        {
            _context = context;
        }

        public void AddProducts(Product p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Products.Add(p);
            _context.SaveChanges();
        }

        public void DeleteProduct(Product p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            _context.Products.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.IdProduct == id);
        }

        public void UpdateProduct(Product p)
        {
            _context.SaveChanges();
        }

    }
}
