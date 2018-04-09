using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ToDoList.Api.Controllers;

namespace ToDoList.Api.Unit.Tests.Controllers
{
    public class DocumentationControllerTests
    {
        [Test]
        public void ShouldBeAsignableToController()
        {
            var controller = new DocumentationController();

            controller.Should().BeAssignableTo<Controller>();
        }

        [Test]
        public void ShouldBeDecoratedWithTheRouteAttributeWithApiRoute()
        {
            typeof(DocumentationController).Should().BeDecoratedWith<RouteAttribute>(routeAttribute => routeAttribute.Template == "api");
        }

        [Test]
        public void Status_ShouldReturn200Response()
        {
            var documentationController = new DocumentationController();

            var result = documentationController.Status() as OkResult;

            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
        }
    }
}
