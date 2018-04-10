using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using ToDoList.Api.Providers;

namespace ToDoList.Api.Unit.Tests.Dependency
{
    public class DocumentationDependenciesTests
    {
        [Test]
        public void IVersionProvider_ShouldBindToVersionProvider()
        {
            var target = new Startup();
            var services = new ServiceCollection();

            target.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            var versionProvider = serviceProvider.GetService<IVersionProvider>();

            versionProvider.GetType().Should().Be<VersionProvider>();
        }

        [Test]
        public void VersionProvider_ShouldBeRegisteredAsSingleton()
        {
            var target = new Startup();
            var services = new ServiceCollection();

            target.ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();
            var firstVersionProvider = serviceProvider.GetService<IVersionProvider>();
            var secondVersionProvider = serviceProvider.GetService<IVersionProvider>();

            firstVersionProvider.Should().BeSameAs(secondVersionProvider);
        }
    }
}
