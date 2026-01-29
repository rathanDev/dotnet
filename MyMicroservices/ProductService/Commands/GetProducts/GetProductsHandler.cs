using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.DTOs;

namespace ProductService.Commands.GetProducts;

public class GetProductsHandler
{
    private readonly AppDbContext _appDbContext;

    public GetProductsHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<List<ProductDto>> HandleAsync(GetProductsQuery query)
    {
        var products = await _appDbContext.Products.ToListAsync();
        var productDtos = products.Select(p => new ProductDto(p.Id, p.Name, p.Description, p.Price)).ToList();
        return productDtos;
    }

}
