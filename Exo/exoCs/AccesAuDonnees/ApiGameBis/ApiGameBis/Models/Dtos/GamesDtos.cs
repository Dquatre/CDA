using ApiGameBis.Models.Data;

namespace ApiGameBis.Models.Dtos
{
    public class GamesDtoFull
    {
        public string Title { get; set; } = null!;

        public string? SubTitle { get; set; }

        public int? ReleaseYear { get; set; }

        public virtual ICollection<GamesPlatformsDto> ListGamesPlatforms { get; set; } = new List<GamesPlatformsDto>();

        public virtual SeriesDto? GameSerie { get; set; }
    }
    public class GamesDtoWithSerie
    {
        public string Title { get; set; } = null!;

        public string? SubTitle { get; set; }

        public int? ReleaseYear { get; set; }

        public virtual Serie? GameSerie { get; set; }
    }

    public class GamesDtoOut
    {
        public string Title { get; set; } = null!;

        public string? SubTitle { get; set; }

        public int? ReleaseYear { get; set; }

        public String SerieName { get; set; } = null!;
    }
    public class GamesDto
    {
        public string Title { get; set; } = null!;

        public string? SubTitle { get; set; }

        public int? ReleaseYear { get; set; }

    }
}
