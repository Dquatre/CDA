using ApiGame.Data.Models;

namespace ApiGame.Data.Dtos
{
    public class GameConsolesDTOFull
    {
        public string Nom { get; set; } = null!;

        public string Constructeur { get; set; } = null!;

        public int AnneeSortie { get; set; }

        public ICollection<GamesPartDTO> Games { get; set; } = new List<GamesPartDTO>();
    }

    public class GameConsolesDTO
    {

        public string Nom { get; set; } = null!;

        public string Constructeur { get; set; } = null!;

        public int AnneeSortie { get; set; }

    }
}
