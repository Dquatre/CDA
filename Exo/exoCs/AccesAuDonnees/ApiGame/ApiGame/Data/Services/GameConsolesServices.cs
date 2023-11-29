using ApiGame.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGame.Data.Services
{
    public class GameConsolesServices
    {
        private readonly ConsoleDbContext _context;

        public GameConsolesServices(ConsoleDbContext context)
        {
            _context = context;
        }

        public void AddGameConsoles(GameConsole gc)
        {
            if (gc == null)
            {
                throw new ArgumentNullException(nameof(gc));
            }
            _context.GameConsoles.Add(gc);
            _context.SaveChanges();
        }
        public void DeleteGameConsole(GameConsole gc)
        {
            //si l'objet GameConsole est null, on renvoi une exception
            if (gc == null)
            {
                throw new ArgumentNullException(nameof(gc));
            }
            // on met à jour le context
            _context.GameConsoles.Remove(gc);
            _context.SaveChanges();
        }
        public IEnumerable<GameConsole> GetAllGameConsoles()
        {
            return _context.GameConsoles.Include("Games").ToList();
        }
        public GameConsole GetGameConsoleById(int id)
        {
            return _context.GameConsoles.Include("Games").FirstOrDefault(gc => gc.IdGameConsole == id);
        }

        public GameConsole GetGameConsoleByName(String nom)
        {
            return _context.GameConsoles.FirstOrDefault(gc => gc.Nom == nom);
        }

        public void UpdateGameConsole(GameConsole gc)
        {
            _context.SaveChanges();
        }
    }
}
