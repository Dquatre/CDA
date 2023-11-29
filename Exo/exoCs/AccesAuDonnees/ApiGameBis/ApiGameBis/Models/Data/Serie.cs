using System;
using System.Collections.Generic;

namespace ApiGameBis.Models.Data;

public partial class Serie
{
    public int IdSerie { get; set; }

    public string SerieName { get; set; } = null!;

    public virtual ICollection<Game> ListGames { get; set; } = new List<Game>();
}
