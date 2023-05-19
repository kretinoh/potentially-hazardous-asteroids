using api_neo_nasa.Models;
using api_neo_nasa.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using api_neo_nasa.Utils.Interface;


namespace api_neo_nasa.Controllers
{
    [ApiController]
    [Route("asteroids")]
    public class AsteroidsController : ControllerBase
    {
        private readonly IAsteroidServices _asteroidServices;
        private readonly HttpClient _httpClient;
        private readonly IUtils _util;

        public AsteroidsController(IAsteroidServices asteroidServices, HttpClient httpClient, IUtils util)
        {
            this._asteroidServices = asteroidServices;
            _httpClient = httpClient;
            this._util = util;
        }

        //TODO: los mensajes de error se devuelven en texto plano, devuélvelos en formato json
        //FIXED
        [HttpGet]
        public virtual async Task<IActionResult> Get([Required(ErrorMessage ="El campo days es requerido")]
                                                string days)
        // Im using DataAnnotation to validate if the user use this method without {days} parameter.
        {
            try
            {
                _util.CheckParameter(days); // This method is used to check the posibly errors and throw exception
                string url = _asteroidServices.GenerateUrlPersonal(days);

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    //TODO: en la arquitectura que estás usando la llamada a la api de la nasa debe de hacerse en el servicio
                    //FIXED
                    return Ok(_asteroidServices.FromResponseReturnListOfModel(response));
                }
                else
                {
                    throw new Exception($"Ha ocurrido un error: {response.StatusCode}");
                }
            }
            catch (ArgumentNullException e)
            {
                return BadRequest(_util.MakeExceptionMessageJSON(e.Message));
            }
            catch (ArgumentOutOfRangeException e)
            {
                return BadRequest(_util.MakeExceptionMessageJSON(e.Message));
            }
            catch (Exception e)
            {
                return BadRequest(_util.MakeExceptionMessageJSON(e.Message));
            }
        }

        //TODO: en el controlador sólo debe haber endpoints, extraelo a una clase de utils o usa la solución
        //que creas conveniente
        //FIXED
        }
}
