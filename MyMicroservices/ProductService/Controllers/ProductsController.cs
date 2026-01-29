using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = new[]
        {
            new { Id = 1, Name = "Product A", Price = 10.0 },
            new { Id = 2, Name = "Product B", Price = 20.0 },
            new { Id = 3, Name = "Product C", Price = 30.0 }
        };
        return Ok(products);
    }

}
