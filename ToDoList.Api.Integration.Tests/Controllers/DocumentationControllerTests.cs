using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;

namespace ToDoList.Api.Integration.Tests.Controllers
{
    public class DocumentationControllerTests
    {
        [Test]
        public async Task Status_ShouldReturnApplicationVersion()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            var client = server.CreateClient();

            var response = await client.GetAsync("/api/status");

            var responseContent = await response.Content.ReadAsStringAsync();

            responseContent.Should().MatchRegex(@"^\d+\.\d+\.\d+(\.\d+)?$");
        }
    }
}
