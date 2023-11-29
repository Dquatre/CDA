using System;
using System.Collections.Generic;

namespace ApiGameBis.Models.Data;

public partial class Platform
{
    public int IdPlatform { get; set; }

    public string PlatformName { get; set; } = null!;

    public string Constructor { get; set; } = null!;

    public virtual ICollection<GamesPlatform> ListGamesPlatforms { get; set; } = new List<GamesPlatform>();
}
