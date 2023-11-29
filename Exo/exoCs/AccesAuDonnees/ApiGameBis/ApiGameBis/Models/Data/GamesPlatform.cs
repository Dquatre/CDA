using System;
using System.Collections.Generic;

namespace ApiGameBis.Models.Data;

public partial class GamesPlatform
{
    public int IdGamePlatform { get; set; }

    public int? IdGame { get; set; }

    public int? IdPlatform { get; set; }

    public virtual Game? PlatformGame { get; set; }

    public virtual Platform? GamePlatform { get; set; }
}
