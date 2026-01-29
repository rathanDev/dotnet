using ProductService.DTOs;
using ProductService.Services.Interfaces;

namespace ProductService.Commands.GetProducts;

public class GetProductsHandler
{
    private readonly IProductService _productService;

    public GetProductsHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<List<ProductDto>> HandleAsync(GetProductsQuery query)
    {
        return await _productService.GetProductsAsync();
    }

}
