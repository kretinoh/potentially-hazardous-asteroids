using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace api_neo_nasa.Models
{
    public class NEOModel
    {
        [JsonProperty("near_earth_objects")]
        public Dictionary<string, Day[]> Objects { get; set; }

    }
}
