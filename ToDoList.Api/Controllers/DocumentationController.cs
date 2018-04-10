using System.Net;
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

        [HttpGet("status")]
        public IActionResult Status()
        {
            var statusResponse = Json(new { version = _versionProvider.GetVersion()});
            statusResponse.StatusCode = 200;

            return statusResponse;
        }
    }
}