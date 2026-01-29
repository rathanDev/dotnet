using ProductService.Data;
using ProductService.Models;

namespace ProductService.Commands.CreateProducts;

public class CreateProductHandler
{

    private readonly AppDbContext _appDbContext;

    public CreateProductHandler(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<int> HandleAsync(CreateProductCommand command)
    {
        var product = new Product( command.Name, command.Description, command.Price);
        _appDbContext.Products.Add(product);
        await _appDbContext.SaveChangesAsync();
        return product.Id;
    }

}
