using ProductService.DTOs;

namespace ProductService.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductDto>> GetProductsAsync();

    Task<ProductDto?> GetProductByNameAsync(string name);

    Task<int> CreateProductAsync(CreateProductRequest req);
}
