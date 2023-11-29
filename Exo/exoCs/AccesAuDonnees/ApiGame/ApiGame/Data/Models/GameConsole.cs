using System;
using System.Collections.Generic;

namespace ApiGame.Data.Models;

public partial class GameConsole
{
    public int IdGameConsole { get; set; }

    public string Nom { get; set; } = null!;

    public string Constructeur { get; set; } = null!;

    public int AnneeSortie { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
