using ApiGame.Data.Models;

namespace ApiGame.Data.Dtos
{
    public class GamesDTOFull
    {

        public string Titre { get; set; } = null!;

        public string? SousTitre { get; set; }

        public int AnneeSortie { get; set; }

        public GameConsolesDTO IdGameConsoleNavigation { get; set; } = null!;
    }

    public class GamesPartDTO
    {

        public string Titre { get; set; } = null!;

        public string? SousTitre { get; set; }

        public int AnneeSortie { get; set; }

    }
    public class GamesDTO
    {

        public string Titre { get; set; } = null!;

        public string? SousTitre { get; set; }

        public int AnneeSortie { get; set; }
        public string GameConsoleName { get; set; } = null!;

    }
}
