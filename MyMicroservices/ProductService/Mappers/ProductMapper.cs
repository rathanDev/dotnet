using ProductService.DTOs;
using ProductService.Models;

namespace ProductService.Mappers;

public static class ProductMapper
{

    public static ProductDto ToDto(Product product)
    {
        return new ProductDto(product.Id, product.Name, product.Description, product.Price);
    }

}
