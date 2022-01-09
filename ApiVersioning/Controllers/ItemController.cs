using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetItemv1([FromRoute] int id)
        {
            var item = new Itemv1
            {
                Id = id,
                Name = "ABC"
            };
            return Ok(item);
        }

        [HttpGet("{id}")]
        [MapToApiVersion("2.0")]
        public IActionResult GetItemv2([FromRoute] int id)
        {
            var item = new Itemv2
            {
                Id = id,
                ProductName = "XYZ"
            };
            return Ok(item);

        }
    }
}
