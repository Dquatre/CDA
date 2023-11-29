using ApiGame.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGame.Data.Services
{
    public class GamesServices
    {
        private readonly ConsoleDbContext _context;

        public GamesServices(ConsoleDbContext context)
        {
            _context = context;
        }

        public void AddGames(Game g)
        {
            if (g == null)
            {
                throw new ArgumentNullException(nameof(g));
            }
            _context.Games.Add(g);
            _context.SaveChanges();
        }
        public void DeleteGame(Game g)
        {
            //si l'objet personne est null, on renvoi une exception
            if (g == null)
            {
                throw new ArgumentNullException(nameof(g));
            }
            // on met à jour le context
            _context.Games.Remove(g);
            _context.SaveChanges();
        }
        public IEnumerable<Game> GetAllGames()
        {
            return _context.Games.Include("IdGameConsoleNavigation").ToList();
        }
        public Game GetGameById(int id)
        {
            return _context.Games.Include("IdGameConsoleNavigation").FirstOrDefault(g => g.IdGame == id);
        }

        public void UpdateGame(Game g)
        {
            _context.SaveChanges();
        }
    }
}
