using ApiGameBis.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiGameBis.Models.Services
{
    public class GamesPlatformsServices
    {
        private readonly PlatformDbContext _context;
        public GamesPlatformsServices(PlatformDbContext context)
        {
            _context = context;
        }

        public void AddGamesPlatforms(GamesPlatform p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.GamesPlatforms.Add(p);
            _context.SaveChanges();
        }

        public void DeleteGamesPlatform(GamesPlatform p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            _context.GamesPlatforms.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<GamesPlatform> GetAllGamesPlatforms()
        {
            return _context.GamesPlatforms.Include("PlatformGame").Include("GamePlatform").ToList();
        }

        public GamesPlatform GetGamesPlatformById(int id)
        {
            return _context.GamesPlatforms.Include("PlatformGame").Include("GamePlatform").FirstOrDefault(p => p.IdGamePlatform == id);
        }

        public void UpdateGamesPlatform(GamesPlatform p)
        {
            _context.SaveChanges();
        }
    }
}
