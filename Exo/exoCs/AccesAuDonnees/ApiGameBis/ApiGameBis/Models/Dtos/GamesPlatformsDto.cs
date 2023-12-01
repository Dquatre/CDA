using ApiGameBis.Models.Data;

namespace ApiGameBis.Models.Dtos
{
    public class GamesPlatformsDtoWithPlatformGame
    {
        public int IdGamePlatform { get; set; }

        public int? IdGame { get; set; }

        public int? IdPlatform { get; set; }
        public virtual PlatformsDtoLink? GamePlatform { get; set; }
    }

    public class GamesPlatformsDto
    {
        public virtual PlatformsDtoLink? GamePlatform { get; set; }
        public virtual GamesDto? Games { get; set; }
    }
}
