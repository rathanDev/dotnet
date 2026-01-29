namespace ProductService.Models;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }

    private Product()
    {
    }

    public Product(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

}
