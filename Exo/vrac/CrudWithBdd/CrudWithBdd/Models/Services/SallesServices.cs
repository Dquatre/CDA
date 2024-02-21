using CrudWithBdd.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWithBdd.Models.Services
{
    public class SallesServices
    {

        private readonly ComplexDbContext _context;
        public SallesServices(ComplexDbContext context)
        {
            _context = context;
        }

        public void AddSalles(Salle p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Salles.Add(p);
            _context.SaveChanges();
        }

        public void DeleteSalle(Salle p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            _context.Salles.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<Salle> GetAllSalles()
        {
            return _context.Salles.ToList();
        }

        public Salle GetSalleById(int id)
        {
            return _context.Salles.FirstOrDefault(p => p.IdSalle == id);
        }

        public void UpdateSalle(Salle p)
        {
            _context.SaveChanges();
        }

    }
}
