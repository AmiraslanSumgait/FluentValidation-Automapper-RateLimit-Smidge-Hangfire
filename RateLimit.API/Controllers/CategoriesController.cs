using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RateLimit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public IActionResult GetCategory()
        {
            return Ok(new { Id = 1, Category = "MobilePhones" });
        }
    }
}
