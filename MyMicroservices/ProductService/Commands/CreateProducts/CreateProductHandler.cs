using MediatR;
using ProductService.DTOs;
using ProductService.Services.Interfaces;

namespace ProductService.Commands.CreateProducts;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
{

    private readonly IProductService _productService;

    public CreateProductHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<ProductDto> Handle(CreateProductCommand command, CancellationToken token)
    {
        var req = new CreateProductRequest { 
            Name = command.Name, 
            Description = command.Description, 
            Price = command.Price 
        };
        var product = await _productService.CreateProductAsync(req);
        return product;
    }

}
