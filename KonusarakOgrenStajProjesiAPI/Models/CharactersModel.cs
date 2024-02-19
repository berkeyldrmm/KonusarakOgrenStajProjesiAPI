using Newtonsoft.Json;

namespace KonusarakOgrenStajProjesiAPI.Models
{
    public class CharactersModel
    {
        [JsonProperty("info")]
        public InfoModel Info { get; set; }

        [JsonProperty("results")]
        public CharacterModel[] Results { get; set; }
    }

    //public partial class Welcome1
    //{
    //    [JsonProperty("info")]
    //    public InfoModel Info { get; set; }

    //    [JsonProperty("results")]
    //    public Result[] Results { get; set; }
    //}

    //public partial class Result
    //{
    //    [JsonProperty("id")]
    //    public long Id { get; set; }

    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("status")]
    //    public Status Status { get; set; }

    //    [JsonProperty("species")]
    //    public Species Species { get; set; }

    //    [JsonProperty("type")]
    //    public string Type { get; set; }

    //    [JsonProperty("gender")]
    //    public Gender Gender { get; set; }

    //    [JsonProperty("origin")]
    //    public Location Origin { get; set; }

    //    [JsonProperty("location")]
    //    public Location Location { get; set; }

    //    [JsonProperty("image")]
    //    public Uri Image { get; set; }

    //    [JsonProperty("episode")]
    //    public Uri[] Episode { get; set; }

    //    [JsonProperty("url")]
    //    public Uri Url { get; set; }

    //    [JsonProperty("created")]
    //    public DateTimeOffset Created { get; set; }
    //}

    //public partial class Location
    //{
    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("url")]
    //    public string Url { get; set; }
    //}

    //public enum Gender { Female, Male, Unknown };

    //public enum Species { Alien, Human };

    //public enum Status { Alive, Dead, Unknown };
}
