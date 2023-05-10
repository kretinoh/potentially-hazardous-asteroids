using api_neo_nasa.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;

namespace TestProject1.Mocks
{
    public class MockHttpContext
    {
        [Test]
        public async Task SetHttpContext_ParameterIsNull_ReturnsOkObjectResult()
        {
            string days = "2";
            var controllerMock = new Mock<AsteroidsController>();
            string jsonContent = File.ReadAllText("C:\\Users\\RAFAEL.MAESTRE\\source\\repos\\PruebaNET\\TestProject1\\Mocks\\Resources\\ResponseBody.json");
            var jsonResponse = JsonConvert.DeserializeObject(jsonContent);
            var response = new OkObjectResult(jsonResponse);
            controllerMock.Setup(c => c.Get(days)).ReturnsAsync(response);

            var micontroller = controllerMock.Object;

            var result = await micontroller.Get(days);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());

        }
    }
}
