using System.Text.Json.Serialization;

namespace api_neo_nasa.Models
{
    //TODO: los dtos y los modelos de deserialización de json deben estar en carpetas separadas
    public class NEODTO
    {
        [JsonPropertyName("nombre")]
        public string Name { get; set; }
        [JsonPropertyName("diametro")]
        public double Average { get; set; }
        [JsonPropertyName("velocidad")]
        public string Speed { get; set; }
        [JsonPropertyName("fecha")]
        public string Date { get; set; }
        [JsonPropertyName("planeta")]
        public string Planet { get; set; }
    }
}
