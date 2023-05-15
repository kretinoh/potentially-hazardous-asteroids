using api_neo_nasa.Models;
using api_neo_nasa.Services.Interface;

namespace api_neo_nasa.Services
{
    public class AsteroidServices : IAsteroidServices
    {
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
                            Mean = day.Mean,
                            Speed = day.Speed,
                            Date = day.Date,
                            Planet = day.Planet
                        });

                    }
                }
            }
            return AsteroidsList.OrderByDescending(x => x.Mean).Take(3).ToList();
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
            return $"{GetBaseUrl()}{MakeUrlVariables(days)[0]}{MakeUrlVariables(days)[1]}&api_key={GetPersonalKey()}";
        }

        public string GenerateUrlDemo(string days)
        {
            return $"{GetBaseUrl()}{MakeUrlVariables(days)[0]}{MakeUrlVariables(days)[1]}&api_key={GetDemoKey()}";
        }

        private static string GetPersonalKey()
        {
            return "sODHDFXQESqJQXNkwuXbOcea3h0K1MX5ydKTvIwi";
        }
        private static string GetDemoKey()
        {
            return "DEMO_KEY";
        }
        private static string GetBaseUrl()
        {
            return "https://api.nasa.gov/neo/rest/v1/feed";
        }
    }
}
