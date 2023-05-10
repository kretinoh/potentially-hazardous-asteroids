using api_neo_nasa.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestApiNeo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Get_correcto()
        {
            int days = 6; 
            AsteroidsController controller = new();
            var resultado = controller.Get(days);

            Assert.IsInstanceOfType(resultado, typeof(OkResult));
        }
    }
}