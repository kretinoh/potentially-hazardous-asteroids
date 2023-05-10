using api_neo_nasa.Controllers;
using api_neo_nasa.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestNEOApi
{
    [TestClass]
    public class TestAsteroidsController
    {
        AsteroidsController _asteroids = new();
        [Test]
        public void GetAsteroids_ShouldReturnAsteroids()
        {
            var cosas = _asteroids.Get(1);
        }
        private List<NEODTO> GetTestProducts()
        {
            var testAsteroids = new List<NEODTO>
            {
                new NEODTO { Name = "Rafa", Mean = 0.234635645, Speed = "12314.123123", Date = "2023-12-06", Planet = "Earth" },
                new NEODTO { Name = "Alex", Mean = 0.234635645, Speed = "12314.123123", Date = "2023-12-06", Planet = "Earth" },
                new NEODTO { Name = "Bumbi", Mean = 0.234635645, Speed = "12314.123123", Date = "2023-12-06", Planet = "Earth" }
            };

            return testAsteroids;
        }
    }
}
