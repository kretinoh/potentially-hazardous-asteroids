using Newtonsoft.Json;
using System.Collections;
using System.Linq;
using System.Text.Json.Serialization;

namespace api_neo_nasa.Models
{
    public class Day
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public double Mean => CalculateMean();
        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool Dangerous { get; set; }
        public string Date => GetApproachData()[0];
        public string Planet => GetApproachData()[1];
        public string Speed => GetApproachData()[2];

        [JsonProperty("estimated_diameter")] // I use this field to calculate the mean
        private Dictionary<string, Dictionary<string, double>> Measures { get; set; }
        [JsonProperty("close_approach_data")]
        public List<CloseApproachData> CloseApproachData { get; set; }

        // Functions

        public double CalculateMean()
        {
            var kilometers = Measures["kilometers"];
            double total = 0;
            foreach (var k in kilometers)
            {
                total += k.Value;

            }
            return total / 2;
        }

        public List<string> GetApproachData()
        {
            var list = new List<string>
            {
                GetDate(),
                GetPlanet(),
                GetSpeed()
            };
            return list;
        }
        public string GetDate()
        {
            return CloseApproachData.Select(x => x.Date.ToString("yyyy-MM-dd")).FirstOrDefault().ToString();
        }
        public string GetPlanet()
        {
            return CloseApproachData.Select(x => x.Planet).FirstOrDefault().ToString();
        }

        public string GetSpeed()
        {
            return CloseApproachData.Select(x=>x.RelativeSpeed).FirstOrDefault().Speed.ToString();
        }

    }
}
