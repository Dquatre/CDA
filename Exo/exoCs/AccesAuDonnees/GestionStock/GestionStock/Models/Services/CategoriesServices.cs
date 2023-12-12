using GestionStock.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Models.Services
{
    public class CategoriesServices
    {

        private readonly GestionStockDbContext _context;
        public CategoriesServices(GestionStockDbContext context)
        {
            _context = context;
        }

        public void AddCategories(Category p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Categories.Add(p);
            _context.SaveChanges();
        }

        public void DeleteCategory(Category p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            _context.Categories.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAllCategorys()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(p => p.IdCategorie == id);
        }

        public void UpdateCategory(Category p)
        {
            _context.SaveChanges();
        }

    }
}
