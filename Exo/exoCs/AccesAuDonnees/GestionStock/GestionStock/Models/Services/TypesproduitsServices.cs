using GestionStock.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Models.Services
{
    public class TypesproduitsServices
    {

        private readonly GestionStockDbContext _context;
        public TypesproduitsServices(GestionStockDbContext context)
        {
            _context = context;
        }

        public void AddTypesproduits(Typesproduit p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Typesproduits.Add(p);
            _context.SaveChanges();
        }

        public void DeleteTypesproduit(Typesproduit p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            _context.Typesproduits.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<Typesproduit> GetAllTypesproduits()
        {
            return _context.Typesproduits.ToList();
        }

        public Typesproduit GetTypesproduitById(int id)
        {
            return _context.Typesproduits.FirstOrDefault(p => p.IdTypeProduit == id);
        }

        public void UpdateTypesproduit(Typesproduit p)
        {
            _context.SaveChanges();
        }

    }
}
