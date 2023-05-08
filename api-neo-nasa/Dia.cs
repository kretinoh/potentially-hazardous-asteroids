using Newtonsoft.Json;
using System.Collections;
using System.Text.Json.Serialization;

namespace api_neo_nasa
{
    //POR CADA DIA QUEREMOS QUE NOS MUESTRE LA SIGUIENTE INFORMACIÓN
    public class Dia
    {
        [JsonProperty("name")]
        public string nombre { get; set; }
        public double MyProperty => calculado();

        
        [JsonProperty("estimated_diameter")]
        [Newtonsoft.Json.JsonIgnore]
        public Dictionary<string,Dictionary<string,double>> Tamaños { get; set; }
        
        public double calculado()
        {
            double diametro = 0;
            foreach(var item in Tamaños.Values.First())
            {
                diametro += item.Value;

            }
            return diametro / 2;
        }
    }
}
