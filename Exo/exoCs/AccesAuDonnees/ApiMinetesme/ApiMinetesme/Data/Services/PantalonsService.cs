using ApiMinetesme.Data.Models;

namespace ApiMinetesme.Data.Services
{
    public class PantalonsService
    {
        private readonly PantalonDbContext _context;
        public PantalonsService(PantalonDbContext context)
        {
            _context = context;
        }

        public void AddPantalons(Pantalon p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Pantalons.Add(p);
            _context.SaveChanges();
        }
        public void DeletePantalon(Pantalon p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            _context.Pantalons.Remove(p);
            _context.SaveChanges();
        }
        public IEnumerable<Pantalon> GetAllPantalons()
        {
            return _context.Pantalons.ToList();
        }
        public Pantalon GetPantalonById(int id)
        {
            return _context.Pantalons.FirstOrDefault(p => p.Id == id);
        }
        public void UpdatePantalon(Pantalon p)
        {
            _context.SaveChanges();
        }
    }
}
