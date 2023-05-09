using api_neo_nasa.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace api_neo_nasa.Controllers
{
    [ApiController]
    [Route("asteroids")]
    public class AsteroidsController : ControllerBase
    {
        // Guardo estos datos para acceder a ellos desde cada controlador si la aplicación creciese.
        const string API_URL = "https://api.nasa.gov/neo/rest/v1/feed";
        private readonly string PERSONAL_KEY = "sODHDFXQESqJQXNkwuXbOcea3h0K1MX5ydKTvIwi";
        private readonly string DEMO_KEY = "DEMO_KEY";

        [HttpGet]
        public async Task<IActionResult> Get([Required(ErrorMessage ="El campo days es requerido")]
                                                int days)
        // Im using DataAnnotation to validate if the user use this method without {days} parameter.
        {
            string url = GenerateParametersUrl(days, PERSONAL_KEY);

            HttpClient client = new();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // If the response returns a 200 code i take de data and deserialize it into my model.
                var jsonBody = await response.Content.ReadAsStringAsync();
                var deserializedData = JsonConvert.DeserializeObject<NEOModel>(jsonBody);

                List<NEODTO> AsteroidsList = new(); // This List is used to save all AsteroidsDTO that were gona declare
                foreach (var item in deserializedData.Objects)
                {
                    foreach (var dia in item.Value)
                    {
                        if (dia.Dangerous) // We only gonna display to the user the top 3 dangerous new earth objects order by descending mean
                        {
                            AsteroidsList.Add(new NEODTO
                            {
                                Name = dia.Name,
                                Mean = dia.Mean,
                                Speed = dia.Speed,
                                Date = dia.Date,
                                Planet = dia.Planet
                            });

                        }
                    }
                }
                return Ok(AsteroidsList.OrderByDescending(x => x.Mean)
                    .Take(3));
            }
            else
            {
                return BadRequest(response);
            }
        }


        private static string GenerateParametersUrl(int days, string KEY)
        {
            string startDate = $"?start_date={DateTime.Today:yyyy-MM-dd}";
            string endDate = $"&end_date={DateTime.Today.AddDays(days):yyyy-MM-dd}";
            return $"{API_URL}{startDate}{endDate}&api_key={KEY}";

        }
    }
}
