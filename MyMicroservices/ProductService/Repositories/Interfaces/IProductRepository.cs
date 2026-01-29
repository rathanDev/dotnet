using ProductService.Models;

namespace ProductService.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<int> AddAsync(Product product);
}
