using ProductService.DTOs;
using ProductService.Mappers;
using ProductService.Models;
using ProductService.Repositories.Interfaces;
using ProductService.Services.Interfaces;

namespace ProductService.Services;

public class ProductServiceImpl : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductServiceImpl(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<int> CreateProductAsync(CreateProductRequest req)
    {
        var product = new Product(req.Name, req.Description, req.Price);
        await _productRepository.AddAsync(product);
        return product.Id;
    }

    public Task<ProductDto?> GetProductByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProductDto>> GetProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return products.Select(p => ProductMapper.ToDto(p)).ToList();
    }
}
