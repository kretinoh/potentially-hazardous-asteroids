using api_neo_nasa.Models;
using api_neo_nasa.Services.Interface;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using api_neo_nasa.DTO;

namespace api_neo_nasa.Services
{
    public class AsteroidServices : IAsteroidServices
    {
        private readonly IConfiguration _configuration;

        public AsteroidServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<NEODTO> FromResponseReturnListOfModel(HttpResponseMessage httpResponseMessage)
        {
            var jsonBody = httpResponseMessage.Content.ReadAsStringAsync().Result;
            var deserialized = JsonConvert.DeserializeObject<NEOModel>(jsonBody);
            return GetOcurrencesOrdererBySize(deserialized);
        }

        public List<NEODTO> GetOcurrencesOrdererBySize(NEOModel model)
        {
            List<NEODTO> AsteroidsList = new(); // This List is used to save all AsteroidsDTO that were gona declare

            foreach (var item in model.Objects)
            {
                foreach (var day in item.Value)
                {
                    if (day.Dangerous) // We only gonna display to the user the top 3 dangerous new earth objects order by descending mean
                    {
                        AsteroidsList.Add(new NEODTO
                        {
                            Name = day.Name,
                            Average = day.Average,
                            Speed = day.Speed,
                            Date = day.Date,
                            Planet = day.Planet
                        });

                    }
                }
            }
            return AsteroidsList.OrderByDescending(x => x.Average).Take(3).ToList();
        }

        private static List<string> MakeUrlVariables(string days)
        {
            string startDate = $"?start_date={DateTime.Today:yyyy-MM-dd}";
            string endDate = $"&end_date={DateTime.Today.AddDays(Int32.Parse(days)):yyyy-MM-dd}";

            var lista = new List<string>
            {
                startDate,
                endDate
            };

            return lista;
        }

        public string GenerateUrlPersonal(string days)
        {
            return $"{_configuration["BASE_URL"]}{MakeUrlVariables(days)[0]}{MakeUrlVariables(days)[1]}&api_key={_configuration["API_KEY"]}";
        }

        public string GenerateUrlDemo(string days)
        {
            
            return $"{_configuration["BASE_URL"]}{MakeUrlVariables(days)[0]}{MakeUrlVariables(days)[1]}&api_key={_configuration["API_KEY"]}";
        }

        //TODO: no hardcodees
        //FIXED (Ahora hago uso de secrets.json)
    }
}
