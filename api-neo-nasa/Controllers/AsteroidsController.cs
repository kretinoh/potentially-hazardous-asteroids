using api_neo_nasa.Models;
using api_neo_nasa.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace api_neo_nasa.Controllers
{
    [ApiController]
    [Route("asteroids")]
    public class AsteroidsController : ControllerBase
    {
        private readonly IAsteroidServices _asteroidServices;
        private readonly HttpClient _httpClient;

        public AsteroidsController(IAsteroidServices asteroidServices, HttpClient httpClient)
        {
            this._asteroidServices = asteroidServices;
            _httpClient = httpClient;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get([Required(ErrorMessage ="El campo days es requerido")]
                                                string days)
        // Im using DataAnnotation to validate if the user use this method without {days} parameter.
        {
            try
            {
                CheckParameter(days); // This method is used to check the posibly errors and throw exception
                string url = _asteroidServices.GenerateUrlPersonal(days);

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // If the response returns a 200 code i take de data and deserialize it into my model.
                    var jsonBody = await response.Content.ReadAsStringAsync();

                    var deserializedData = JsonConvert.DeserializeObject<NEOModel>(jsonBody);

                    var result = _asteroidServices.GetOcurrencesOrdererBySize(deserializedData);

                    return Ok(jsonBody);
                }
                else
                {
                    throw new Exception($"Ha ocurrido un error: {response.StatusCode}");
                }
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private static void CheckParameter(string days)
        {
            int parsedDay = int.Parse(days);
            if (days is null)
            {
                throw new ArgumentNullException(nameof(days));
            }
            else if (parsedDay < 1 || parsedDay > 7)
            {
                throw new ArgumentOutOfRangeException(nameof(days));
            }

        }
    }
}
