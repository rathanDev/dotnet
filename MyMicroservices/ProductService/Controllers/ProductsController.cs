using Microsoft.AspNetCore.Mvc;
using ProductService.Commands.CreateProducts;
using ProductService.Commands.GetProducts;

namespace ProductService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly CreateProductHandler _createProductHandler;
    private readonly GetProductsHandler _getProductsHandler;

    public ProductsController(CreateProductHandler createProductHandler, GetProductsHandler getProductsHandler)
    {
        _createProductHandler = createProductHandler;
        _getProductsHandler = getProductsHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _getProductsHandler.HandleAsync(new GetProductsQuery());
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var product = await _createProductHandler.HandleAsync(command);
        return Ok(product);
    }

}
