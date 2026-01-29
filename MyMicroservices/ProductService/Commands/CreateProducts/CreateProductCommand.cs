namespace ProductService.Commands.CreateProducts;

public record CreateProductCommand(string Name, string Description, decimal Price);
