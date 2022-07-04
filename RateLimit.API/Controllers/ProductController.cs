using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RateLimit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(new { Id = 1, Name = "Pencil", Price = 20 });
        }
        //Get api/product/pencil/20
        [HttpGet("{name}")]
        public IActionResult GetProduct(string name,int price)
        {
            return Ok(name);
        }
        [HttpPost]
        public IActionResult SaveProduct()
        {
            return Ok(new { Status="Success"});
        }
        [HttpPut]
        public IActionResult UpdateProduct()
        {
            return Ok();
        }
    }
}
