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
        [JsonPropertyName("description")]
        public double media => Calculado();
        public string fecha => rellenarData()[0];
        public string planeta => rellenarData()[1];
        public string velocidad => rellenarData()[2];

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

        public List<string> rellenarData()
        {
            var list = new List<string>
            {
                GetFecha(),
                getPlaneta(),
                getVelocidad()
            };
            return list;
        }
        public string GetFecha()
        {

            var cosa = close_approach_data.ToArray();
            return cosa.Select(x => x.fecha.ToString("yyyy-MM-dd")).FirstOrDefault().ToString(); 
        }
        public string getPlaneta()
        {
            var cosa = close_approach_data.ToArray();
            return cosa.Select(x => x.planeta).FirstOrDefault().ToString();
        }

        public string getVelocidad()
        {
            var cosa = close_approach_data.ToArray();
            return cosa.Select(x=>x.velocidadRelativa).FirstOrDefault().velocidad.ToString();
        }

    }
}
