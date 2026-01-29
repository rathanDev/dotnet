using MediatR;
using ProductService.DTOs;

namespace ProductService.Queries.GetProducts;

public record GetProductsQuery() : IRequest<List<ProductDto>>;

