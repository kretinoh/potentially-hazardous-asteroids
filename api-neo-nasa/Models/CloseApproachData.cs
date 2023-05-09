using Newtonsoft.Json;

namespace api_neo_nasa.Models
{
    public class CloseApproachData
    {
        [JsonProperty("close_approach_date")]
        public DateTime Date { get; set; }
        [JsonProperty("relative_velocity")]
        public Velocity RelativeSpeed { get; set; }

        [JsonProperty("orbiting_body")]
        public string Planet { get; set; }
    }
}