using Microsoft.AspNetCore.Mvc;

namespace Frost.WebApiVersioning.V2.Controllers
{
    public class HiController : Controller
    {
        [Route("~/api/v2/Hi")] // Attribute routing  
        [HttpGet]
        public IActionResult Get() => Content("Hi Version 2");
    }
}