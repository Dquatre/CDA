using ApiGameBis.Models.Data;

namespace ApiGameBis.Models.Dtos
{
    public class GamesPlatformsDto
    {
        public virtual GamesDto? PlatformGame { get; set; }

        public virtual PlatformsDto? GamePlatform { get; set; }
    }

}
