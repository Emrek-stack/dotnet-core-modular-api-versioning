using Microsoft.AspNetCore.Mvc;

namespace Frost.WebApiVersioning.V1.Controllers
{
    
    public class HiControıller : Controller
    {
        [Route("~/api/v1/Hi")] // Attribute routing  
        [HttpGet]
        public IActionResult Get() => Content("Hi Version 1");
    }
}