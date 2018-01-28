using Microsoft.AspNetCore.Mvc;

namespace Frost.WebApiVersioning.V1.Controllers
{    
    public class HiController : Controller
    {
        [Route("~/api/v1/[controller]")] // Attribute routing  
        [HttpGet]
        public IActionResult Get() => Content("Hi Version 1");
    }
}