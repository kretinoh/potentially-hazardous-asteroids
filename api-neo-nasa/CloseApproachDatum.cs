using Newtonsoft.Json;

namespace api_neo_nasa
{
    public class CloseApproachDatum
    {
        [JsonProperty("close_approach_date")]
        public string fecha { get; set; }
        [JsonProperty("relative_velocity")]
        public Velocity velocidadRelativa { get; set; }
        [JsonProperty("orbiting_body")]
        public string planeta { get; set; }
    }
}