using ProductService.DTOs;
using ProductService.Services.Interfaces;

namespace ProductService.Commands.CreateProducts;

public class CreateProductHandler
{

    private readonly IProductService _productService;

    public CreateProductHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<int> HandleAsync(CreateProductCommand command)
    {
        var req = new CreateProductRequest { 
            Name = command.Name, 
            Description = command.Description, 
            Price = command.Price 
        };
        var id = await _productService.CreateProductAsync(req);
        return id;
    }

}
