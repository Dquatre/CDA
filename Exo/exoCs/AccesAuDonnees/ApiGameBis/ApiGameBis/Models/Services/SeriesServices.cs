using ApiGameBis.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiGameBis.Models.Services
{
    public class SeriesServices
    {
        private readonly PlatformDbContext _context;
        public SeriesServices(PlatformDbContext context)
        {
            _context = context;
        }

        public void AddSeries(Serie p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Series.Add(p);
            _context.SaveChanges();
        }

        public void DeleteSerie(Serie p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            _context.Series.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<Serie> GetAllSeries()
        {
            return _context.Series.Include("ListGames").ToList();
        }

        public Serie GetSerieById(int id)
        {
            return _context.Series.Include("ListGames").FirstOrDefault(p => p.IdSerie == id);
        }

        public Serie GetSerieBySerieName(String name)
        {
            return _context.Series.Include("ListGames").FirstOrDefault(p => p.SerieName == name);
        }

        public void UpdateSerie(Serie p)
        {
            _context.SaveChanges();
        }

    }
}
