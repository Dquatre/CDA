using ApiGameBis.Models.Data;

namespace ApiGameBis.Models.Dtos
{
    public class PlatformsDtoWithListGamesPlatforms
    {
        public string PlatformName { get; set; } = null!;

        public string Constructor { get; set; } = null!;

        public virtual ICollection<GamesPlatformsDto> ListGamesPlatforms { get; set; } = new List<GamesPlatformsDto>();
    }
    public class PlatformsDto
    {
        public string PlatformName { get; set; } = null!;

        public string Constructor { get; set; } = null!;
    }
}
