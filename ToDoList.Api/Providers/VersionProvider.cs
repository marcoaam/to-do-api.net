using System.Reflection;

namespace ToDoList.Api.Providers
{
    public class VersionProvider : IVersionProvider
    {
        public string GetVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}