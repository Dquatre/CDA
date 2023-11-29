using System;
using System.Collections.Generic;

namespace ApiGame.Data.Models;

public partial class Game
{
    public int IdGame { get; set; }

    public string Titre { get; set; } = null!;

    public string? SousTitre { get; set; }

    public int AnneeSortie { get; set; }

    public int IdGameConsole { get; set; }

    public virtual GameConsole IdGameConsoleNavigation { get; set; } = null!;
}
