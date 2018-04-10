using FluentAssertions;
using NUnit.Framework;
using ToDoList.Api.Providers;

namespace ToDoList.Api.Integration.Tests.Providers
{
    public class VersionProviderTests
    {
        [Test]
        public void ShouldImplementIVersionProvider()
        {
            typeof(VersionProvider).Should().BeAssignableTo<IVersionProvider>();
        }

        [Test]
        public void GetVersion_ShouldReturnApplicationVersion()
        {
            var versionProvider = new VersionProvider();

            versionProvider.GetVersion().Should().MatchRegex(@"^\d+\.\d+\.\d+(\.\d+)?$");
        }
    }
}
