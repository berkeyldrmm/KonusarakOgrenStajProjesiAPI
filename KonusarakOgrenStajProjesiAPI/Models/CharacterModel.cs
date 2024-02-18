namespace KonusarakOgrenStajProjesiAPI.Models
{
    public class CharacterModel
    {
        public string Name { get; set; } = null!;

        public string? Status { get; set; }

        public string? Species { get; set; }

        public string? Type { get; set; }

        public string? Gender { get; set; }

        public string? Image { get; set; }

        public string? Url { get; set; }

        public DateTime? Created { get; set; }

        public string? OriginName { get; set; }
        public string? OriginUrl { get; set; }

        public string? LocationName { get; set; }
        public string? LocationUrl { get; set; }
    }
}
