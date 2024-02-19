using Newtonsoft.Json;

namespace KonusarakOgrenStajProjesiAPI.Models
{
    public class EpisodesModel
    {
        [JsonProperty("info")]
        public InfoModel Info { get; set; }

        [JsonProperty("results")]
        public EpisodeModel[] Results { get; set; }
    }

    //public partial class Welcome3
    //{
    //    [JsonProperty("info")]
    //    public Info Info { get; set; }

    //    [JsonProperty("results")]
    //    public Result[] Results { get; set; }
    //}

    //public partial class Info
    //{
    //    [JsonProperty("count")]
    //    public long Count { get; set; }

    //    [JsonProperty("pages")]
    //    public long Pages { get; set; }

    //    [JsonProperty("next")]
    //    public Uri Next { get; set; }

    //    [JsonProperty("prev")]
    //    public object Prev { get; set; }
    //}

    //public partial class Result
    //{
    //    [JsonProperty("id")]
    //    public long Id { get; set; }

    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    [JsonProperty("air_date")]
    //    public string AirDate { get; set; }

    //    [JsonProperty("episode")]
    //    public string Episode { get; set; }

    //    [JsonProperty("characters")]
    //    public Uri[] Characters { get; set; }

    //    [JsonProperty("url")]
    //    public Uri Url { get; set; }

    //    [JsonProperty("created")]
    //    public DateTimeOffset Created { get; set; }
    //}
}
