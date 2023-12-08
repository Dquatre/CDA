using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfCrud01.Models.Data;

namespace WpfCrud01.Models.Services
{
    public class LivresServices
    {
        private readonly LivreDbContext _context;
        public LivresServices(LivreDbContext context)
        {
            _context = context;
        }

        public void AddLivres(Livre p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Livres.Add(p);
            _context.SaveChanges();
        }

        public void DeleteLivre(Livre p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            _context.Livres.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<Livre> GetAllLivres()
        {
            return _context.Livres.ToList();
        }

        public Livre GetLivreById(int id)
        {
            return _context.Livres.FirstOrDefault(p => p.IdLivre == id);
        }

        public void UpdateLivre(Livre p)
        {
            _context.SaveChanges();
        }

    }
}
