using Newtonsoft.Json;

namespace KonusarakOgrenStajProjesiAPI.Models
{
    public class InfoModel
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("pages")]
        public long Pages { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("prev")]
        public object Prev { get; set; }
    }
}
