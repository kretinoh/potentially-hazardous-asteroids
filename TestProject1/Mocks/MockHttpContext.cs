using api_neo_nasa.Controllers;
using api_neo_nasa.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.Protected;
using System.Net;

namespace TestApiNEO.Mocks
{
    public class MockHttpContext
    {
        //TODO: Sólo pruebas los códigos de respuesta, la gracia de mockear es que
        //pruebes que obtienes los objetos con las mismas propiedades que en el json
        [Test]
        public async Task MockTest_DaysNumberOk_ReturnsOkObjectResult()
        {
            //TODO: declaras la misma string en 2 métodos, extráela
            //TODO: rutas absolutas no, rutas relativas
            string jsonContent = File.ReadAllText("C:\\Users\\JAVIER.ALVAREZCUEV\\RAFApotentially-hazardous-asteroids\\TestProject1\\Mocks\\Resources\\ResponseBody.json");
            var handleMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonContent)
            };

            handleMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            var httpClient = new HttpClient(handleMock.Object)
            {
                BaseAddress = new Uri("https://api.nasa.gov/neo/rest/v1/feed")
            };

            var asteroids = new AsteroidsController(new Mock<IAsteroidServices>().Object,httpClient);
            var result = await asteroids.Get("7") as OkObjectResult;

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }
        
        [Test]
        public async Task MockTest_DaysNumberOutOfBounds_ReturnsBadRequest()
        {
            string jsonContent = File.ReadAllText("C:\\Users\\JAVIER.ALVAREZCUEV\\RAFApotentially-hazardous-asteroids\\TestProject1\\Mocks\\Resources\\ResponseBody.json");
            var handleMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonContent)
            };

            handleMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);
            var httpClient = new HttpClient(handleMock.Object)
            {
                BaseAddress = new Uri("https://api.nasa.gov/neo/rest/v1/feed")
            };

            var asteroids = new AsteroidsController(new Mock<IAsteroidServices>().Object,httpClient);
            var result = await asteroids.Get("17") as BadRequestObjectResult;

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
            Assert.That(result.StatusCode, Is.EqualTo(StatusCodes.Status400BadRequest));
        }
    }
}
