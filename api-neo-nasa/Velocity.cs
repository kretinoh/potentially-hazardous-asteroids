using Newtonsoft.Json;

namespace api_neo_nasa
{
    public class Velocity
    {
        [JsonProperty("kilometers_per_hour")]
        public string velocidad { get; set; }
    }
}