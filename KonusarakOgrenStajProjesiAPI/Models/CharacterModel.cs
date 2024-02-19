using Newtonsoft.Json;

namespace KonusarakOgrenStajProjesiAPI.Models
{
    public partial class CharacterModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("species")]
        public string Species { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("origin")]
        public Location Origin { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("episode")]
        public string[] Episode { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }
    }

    public partial class Location
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

}
