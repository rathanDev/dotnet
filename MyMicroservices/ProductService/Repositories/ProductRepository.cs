using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Models;
using ProductService.Repositories.Interfaces;

namespace ProductService.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _appDbContext;

    public ProductRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> AddAsync(Product product)
    {
        _appDbContext.Products.Add(product);
        await _appDbContext.SaveChangesAsync();
        return product.Id;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        var products = await _appDbContext.Products.AsNoTracking().ToListAsync();
        return products;
    }
}
