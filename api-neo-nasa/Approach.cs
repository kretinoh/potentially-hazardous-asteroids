using Newtonsoft.Json;

namespace api_neo_nasa
{
    public class Approach
    {
        [JsonProperty("close_approach_date")]
        public string close_approach_date { get; set; }
    }
}
