using api_neo_nasa.Controllers;
using api_neo_nasa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        private AsteroidsController _controller;
        [SetUp]
        public void Setup()
        {
            _controller = new AsteroidsController();
        }

        [Test]
        public async Task GetMethod_ReturnsOk()
        {
            string days = "3";

            var result = await _controller.Get(days);

            Assert.That(result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task GetMethod_NullParameter_ReturnsBadRequest()
        {
            string days = null;

            var result = await _controller.Get(days);

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());

        }
        

        [TestCase("-1")]
        [TestCase("10")]
        [TestCase("Bumbi")]
        public async Task GetMethod_InvalidParameter_ReturnsBadRequest(string days)
        {
            var result = await _controller.Get(days);

            Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());

        }
    }
}