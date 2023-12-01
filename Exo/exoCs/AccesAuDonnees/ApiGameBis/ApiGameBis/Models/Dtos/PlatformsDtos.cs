using ApiGameBis.Models.Data;

namespace ApiGameBis.Models.Dtos
{
    public class PlatformsDtoWithListGamesPlatforms
    {
        public string PlatformName { get; set; } = null!;

        public string Constructor { get; set; } = null!;

        public virtual ICollection<GamesPlatformsDtoWithPlatformGame> ListGamesPlatforms { get; set; } = new List<GamesPlatformsDtoWithPlatformGame>();
    }
    public class PlatformsDto
    {
        public string PlatformName { get; set; } = null!;

        public string Constructor { get; set; } = null!;
    }
    public class PlatformsDtoLink
    {
        public string PlatformName { get; set; } = null!;

        public string Constructor { get; set; } = null!;
    }
}
