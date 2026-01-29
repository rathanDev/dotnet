using MediatR;
using ProductService.DTOs;
using ProductService.Services.Interfaces;

namespace ProductService.Queries.GetProducts;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IProductService _productService;

    public GetProductsHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<List<ProductDto>> Handle(GetProductsQuery query, CancellationToken token)
    {
        return await _productService.GetProductsAsync();
    }

}
