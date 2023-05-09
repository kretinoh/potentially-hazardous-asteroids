using Newtonsoft.Json;

namespace api_neo_nasa.Models
{
    public class Velocity
    {
        [JsonProperty("kilometers_per_hour")]
        public string Speed { get; set; }
    }
}