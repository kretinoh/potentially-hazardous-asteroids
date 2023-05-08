using Newtonsoft.Json;
using System.Collections;
using System.Linq;
using System.Text.Json.Serialization;

namespace api_neo_nasa
{
    //POR CADA DIA QUEREMOS QUE NOS MUESTRE LA SIGUIENTE INFORMACIÓN
    public class Dia
    {
        [JsonProperty("name")]
        public string nombre { get; set; }
        public double media => Calculado();
        [JsonProperty("estimated_diameter")]
        private Dictionary<string,Dictionary<string,double>> Tamaños { get; set; }

        public List<CloseApproachDatum> close_approach_data { get; set; }

        public double Calculado()
        {
            var kilometers = Tamaños["kilometers"];
            double total = 0;
            foreach (var k in kilometers)
            {
                total += k.Value;

            }
            return total;
        }
    }
}
