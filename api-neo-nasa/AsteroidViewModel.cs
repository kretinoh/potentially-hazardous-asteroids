using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace api_neo_nasa
{
    public class AsteroidViewModel
    {
        [JsonProperty("near_earth_objects")]
        public Dictionary<string, Dia[]> Objects{ get; set; }
    }
}
