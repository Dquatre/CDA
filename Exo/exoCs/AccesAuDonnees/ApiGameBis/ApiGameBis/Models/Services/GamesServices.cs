using ApiGameBis.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiGameBis.Models.Services
{
    public class GamesServices
    {
        private readonly PlatformDbContext _context;
        public GamesServices(PlatformDbContext context)
        {
            _context = context;
        }

        public void AddGames(Game p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Games.Add(p);
            _context.SaveChanges();
        }

        public void DeleteGame(Game p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            _context.Games.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _context.Games.Include("GameSerie").ToList();
        }

        public Game GetGameById(int id)
        {
            return _context.Games.FirstOrDefault(p => p.IdGame == id);
        }

        public void UpdateGame(Game p)
        {
            _context.SaveChanges();
        }




    }
}
