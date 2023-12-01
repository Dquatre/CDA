using System;
using System.Collections.Generic;

namespace ApiGameBis.Models.Data;

public partial class Game
{
    public Game()
    {
        ListGamesPlatforms = new HashSet<GamesPlatform>();
    }

    public int IdGame { get; set; }

    public string Title { get; set; } = null!;

    public string? SubTitle { get; set; }

    public int? ReleaseYear { get; set; }

    public int? IdSerie { get; set; }

    public virtual ICollection<GamesPlatform> ListGamesPlatforms { get; set; } = new List<GamesPlatform>();

    public virtual Serie? GameSerie { get; set; }
}
