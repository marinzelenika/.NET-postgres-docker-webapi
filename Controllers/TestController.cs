using Microsoft.AspNetCore.Mvc;

namespace SampleAPI.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTest()
        {
            return Ok("Test successful");
        }
    }

}
