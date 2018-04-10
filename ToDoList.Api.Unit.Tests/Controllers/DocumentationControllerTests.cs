using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ToDoList.Api.Controllers;
using ToDoList.Api.Providers;

namespace ToDoList.Api.Unit.Tests.Controllers
{
    public class DocumentationControllerTests
    {
        private Mock<IVersionProvider> _mockVersionProvider;
        private DocumentationController _documentationController;

        [SetUp]
        public void SetUp()
        {
            _mockVersionProvider = new Mock<IVersionProvider>();
            _documentationController = new DocumentationController(_mockVersionProvider.Object);
        }

        [Test]
        public void ShouldBeAsignableToController()
        {
            var controller = _documentationController;

            controller.Should().BeAssignableTo<Controller>();
        }

        [Test]
        public void ShouldBeDecoratedWithTheRouteAttributeWithApiRoute()
        {
            typeof(DocumentationController).Should().BeDecoratedWith<RouteAttribute>(routeAttribute => routeAttribute.Template == "api");
        }

        [Test]
        public void Status_ShouldBeDecoratedWithHttpGetAttributeWithStatusRoute()
        {
            var method = typeof(DocumentationController).GetMethod("Status");

            method.Should().BeDecoratedWith<HttpGetAttribute>(httpGetAttribute => httpGetAttribute.Template == "status");
        }

        [Test]
        public void Status_ShouldReturn200Response()
        {
            var documentationController = _documentationController;

            var result = documentationController.Status() as JsonResult;

            result.Value.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }

        [Test]
        public void Status_ShouldReturnApplicationVersion()
        {
            _mockVersionProvider.Setup(x => x.GetVersion()).Returns("fakeVersion");

            var result = _documentationController.Status() as JsonResult;

            result.Should().NotBeNull();
            result.Value.ToString().Should().Contain("fakeVersion");
        }
    }
}
