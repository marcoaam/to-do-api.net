using Microsoft.AspNetCore.Mvc;

namespace ToDoList.Api.Controllers
{
    [Route("api")]
    public class DocumentationController : Controller
    {
        public IActionResult Status()
        {
            return Ok();
        }
    }
}