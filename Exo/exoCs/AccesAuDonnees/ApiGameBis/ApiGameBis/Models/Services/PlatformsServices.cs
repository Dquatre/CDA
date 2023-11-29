using ApiGameBis.Models.Data;

namespace ApiGameBis.Models.Services
{
    public class PlatformsServices
    { 
        private readonly PlatformDbContext _context;
        public PlatformsServices(PlatformDbContext context)
        {
            _context = context;
        }

        public void AddPlatforms(Platform p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Platforms.Add(p);
            _context.SaveChanges();
        }

        public void DeletePlatform(Platform p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            _context.Platforms.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.IdPlatform == id);
        }

        public void UpdatePlatform(Platform p)
        {
            _context.SaveChanges();
        }


    }
}
