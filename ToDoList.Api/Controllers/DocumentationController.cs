using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.Providers;

namespace ToDoList.Api.Controllers
{
    [Route("api")]
    public class DocumentationController : Controller
    {
        private readonly IVersionProvider _versionProvider;

        public DocumentationController(IVersionProvider versionProvider)
        {
            _versionProvider = versionProvider;
        }

        public IActionResult Status()
        {
            return Ok(_versionProvider.GetVersion());
        }
    }
}